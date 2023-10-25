using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using Task8.Data.Entity.Generated;
using Task8.Events;
using Task8.Views;

namespace Task8.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private object _selectedItem;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            DragWindowCommand = new(DragWindow);
            ExitCommand = new(Exit);
            MinimazeCommand = new(Minimaze);
            NavigateToHomeCommand = new(NavigateToHome);
            NavigateToEdit = new(NavigateToEditCommand);
            _eventAggregator.GetEvent<TreeItemSelectedEvent>().Subscribe(OnTreeItemSelected);
        }

       

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand DragWindowCommand { get; }

        public DelegateCommand ExitCommand { get; }

        public DelegateCommand MinimazeCommand { get; }

        public DelegateCommand NavigateToHomeCommand { get; }

        public DelegateCommand NavigateToEdit {  get; }

        private void NavigateToHome()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), nameof(Home));
            _eventAggregator.GetEvent<HomeNavigateEvent>().Publish();
        }

        private void NavigateToEditCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), CastSelectedItem());
            _regionManager.RequestNavigate(RegionNames.ToolBarRegion.ToString(), nameof(ToolBar));  
            _eventAggregator.GetEvent<EditNavigateEvent>().Publish(_selectedItem);
        }

        private void Minimaze()
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

        private void OnTreeItemSelected(object item)
        {
            _selectedItem = item;
        }

        private string CastSelectedItem()
        {
            return _selectedItem switch
            {
                Course => nameof(CourseEdit),
                _ => ""
            };
        }
    }
}
