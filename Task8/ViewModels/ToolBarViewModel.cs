using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.Events;

namespace Task8.ViewModels
{
    public class ToolBarViewModel : BindableBase
    {
        private Visibility _toolBarVisibility = Visibility.Hidden;
        private readonly IEventAggregator _eventAggregator;

        public Visibility ToolBarVisibility
        {
            get { return _toolBarVisibility; }
            set { SetProperty(ref _toolBarVisibility, value); }
        }

        public ToolBarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<EditNavigateEvent>().Subscribe(OnEditNavigate);
            _eventAggregator.GetEvent<HomeNavigateEvent>().Subscribe(OnHomeNavigate);
        }

        private void OnEditNavigate(object item)
        {
            ToolBarVisibility = Visibility.Visible;
            RaisePropertyChanged(nameof(ToolBarVisibility));
        }

        private void OnHomeNavigate()
        {
            ToolBarVisibility = Visibility.Hidden;
            RaisePropertyChanged(nameof(ToolBarVisibility));
        }
    }
}
