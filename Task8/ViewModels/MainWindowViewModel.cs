using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Resources;
using System.Windows;
using Task8.Data.Entity.Generated;
using Task8.Events;
using Task8.Properties;
using Task8.Views;

namespace Task8.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Task 8";
        private bool _isEditButtonActive = false;
        private object _selectedItem;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;

            DragWindowCommand = new(DragWindow);
            ExitCommand = new(Exit);
            MinimizeCommand = new(Minimize);
            NavigateToHomeCommand = new(NavigateToHome);
            NavigateToEdit = new(NavigateToEditCommand);
            InfoDialogCommand = new(OpenInfoDialog);

            _eventAggregator.GetEvent<TreeItemSelectedEvent>().Subscribe(OnTreeItemSelected);
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool IsEditButtonActive
        {
            get { return _isEditButtonActive; }
            set { SetProperty(ref _isEditButtonActive, value); }
        }

        private void OnTreeItemSelected(object item)
        {
            _selectedItem = item;
            IsEditButtonActive = true;
        }

        private string CastSelectedItem()
        {
            return _selectedItem switch
            {
                Course => nameof(CourseEdit),
                Group => nameof(GroupEdit),
                _ => ""
            };
        }

        #region Commands
        public DelegateCommand DragWindowCommand { get; }

        public DelegateCommand ExitCommand { get; }

        public DelegateCommand MinimizeCommand { get; }

        public DelegateCommand NavigateToHomeCommand { get; }

        public DelegateCommand NavigateToEdit { get; }

        public DelegateCommand InfoDialogCommand { get; }

        private void NavigateToHome()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), nameof(Home));
            _eventAggregator.GetEvent<HomeNavigateEvent>().Publish();
        }

        private void NavigateToEditCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), CastSelectedItem());
            _eventAggregator.GetEvent<EditNavigateEvent>().Publish(_selectedItem);
            IsEditButtonActive = false;
            RaisePropertyChanged(nameof(IsEditButtonActive));
        }

        private void Minimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void DragWindow()
        {
            Application.Current.MainWindow.DragMove();
        }

        private void OpenInfoDialog()
        {
            DialogParameters parameters = new()
            {
                { "Image", @"E:\Task8\Task8\Resources\Снимок.PNG" }
            };

            _dialogService.ShowDialog(DialogNames.InfoDialog.ToString(), parameters, r => { });
        }

        #endregion
    }
}
