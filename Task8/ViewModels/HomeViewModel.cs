using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Events;

namespace Task8.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IHomeModel _homeModel;
        private readonly IEventAggregator _eventAggregator;

        public HomeViewModel(IHomeModel homeModel, IEventAggregator eventAggregator)
        {
            _homeModel = homeModel;
            _eventAggregator = eventAggregator;
            SelectedItemChangedCommand = new(SelectedItemChanged);
        }

        public ObservableCollection<Course> Courses => new(_homeModel.Courses);

        public DelegateCommand<object> SelectedItemChangedCommand { get; }

        private void SelectedItemChanged(object obj)
        {
            _eventAggregator.GetEvent<TreeItemSelectedEvent>().Publish(obj);   
        }
    }
}
