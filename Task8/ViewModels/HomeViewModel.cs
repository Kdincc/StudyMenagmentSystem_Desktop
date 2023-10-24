using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IHomeModel _homeModel;

        public HomeViewModel(IHomeModel homeModel)
        {
            _homeModel = homeModel;
            SelectedItemChangedCommand = new(SelectedItemChanged);
        }

        public ObservableCollection<Course> Courses => new(_homeModel.Courses);

        public DelegateCommand<object> SelectedItemChangedCommand { get; }

        private void SelectedItemChanged(object obj)
        {
            
        }
    }
}
