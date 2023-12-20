using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;

namespace Task8.ViewModels
{
    public class TeachersViewModel : BindableBase
    {
        private readonly ITeachersModel _teachersModel;

        public TeachersViewModel(ITeachersModel teachersModel)
        {
            _teachersModel = teachersModel;
        }
    }
}
