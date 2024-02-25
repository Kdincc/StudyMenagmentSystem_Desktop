using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using Task8.Data.Entity;
using Task8.Data.Entity.Generated;
using Task8.Events;
using Task8.Messagers;
using Task8.Views;

namespace Task8.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Task 8";
        private bool _isEditButtonActive = false;
        private DbEntity _selectedItem;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

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

        private void OnTreeItemSelected(DbEntity item)
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

        public DelegateCommand DragWindowCommand => new(DragWindow);

        public DelegateCommand ExitCommand => new(Exit);

        public DelegateCommand MinimizeCommand => new(Minimize);

        public DelegateCommand NavigateToHomeCommand => new(NavigateToHome);

        public DelegateCommand NavigateToEditCommand => new(NavigateToEdit);

        public DelegateCommand ShowInfoCommand => new(ShowInfo);

        private void NavigateToHome()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), nameof(Home));
            _eventAggregator.GetEvent<HomeNavigateEvent>().Publish();
        }

        private void NavigateToEdit()
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

        private void ShowInfo()
        {
            MainWindowMessager.ShowAppInfoMessage();
        }

        #endregion
    }
}
