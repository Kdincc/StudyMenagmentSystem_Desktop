using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using Task8.Views;

namespace Task8.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _regionManager;
        private Visibility _isEditButtonActive = Visibility.Visible;

        

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            DragWindowCommand = new(DragWindow);
            ExitCommand = new(Exit);
            MinimazeCommand = new(Minimaze);
            NavigateToHomeCommand = new(NavigateToHome);
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public Visibility IsEditButtonActive
        {
            get { return _isEditButtonActive; }
            set { SetProperty(ref _isEditButtonActive, value); }
        }

        public DelegateCommand DragWindowCommand { get; }

        public DelegateCommand ExitCommand { get; }

        public DelegateCommand MinimazeCommand { get; }

        public DelegateCommand NavigateToHomeCommand { get; }

        public void NavigateToHome()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), nameof(Home));
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

    }
}
