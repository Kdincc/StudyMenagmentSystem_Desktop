using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Events;
using Task8.Views;

namespace Task8.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IHomeModel _homeModel;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public HomeViewModel(IHomeModel homeModel, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _homeModel = homeModel;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            NavigateToTeachers = new(NavigateToTeachersCommand);
            SelectedItemChangedCommand = new(SelectedItemChanged);

            _eventAggregator.GetEvent<HomeNavigateEvent>().Subscribe(OnNavigating);
        }

        private void OnNavigating()
        {
            RaisePropertyChanged(nameof(Courses));
        }

        public ObservableCollection<Course> Courses => new(_homeModel.Courses);

        public DelegateCommand<object> SelectedItemChangedCommand { get; }

        public DelegateCommand NavigateToTeachers { get; }

        private void SelectedItemChanged(object obj)
        {
            _eventAggregator.GetEvent<TreeItemSelectedEvent>().Publish(obj);
        }

        private void NavigateToTeachersCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion.ToString(), nameof(Teachers));
        }
    }
}
