using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Events;

namespace Task8.ViewModels
{
    public class CourseEditViewModel : BindableBase
    {
        private readonly ICourseEditModel _courseEditModel;
        private readonly IEventAggregator _eventAggregator;

        public CourseEditViewModel(ICourseEditModel courseEditModel, IEventAggregator eventAggregator)
        {
            
            _courseEditModel = courseEditModel;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<EditNavigateEvent>().Subscribe(OnNavigate);
        }

        public ObservableCollection<Group> Groups => new(_courseEditModel.Groups);

        private void OnNavigate(object item)
        {
            if (item is Course)
            {
                _courseEditModel.InitCourse(item as Course);
                RaisePropertyChanged(nameof(Groups));
            }
        }


    }
}
