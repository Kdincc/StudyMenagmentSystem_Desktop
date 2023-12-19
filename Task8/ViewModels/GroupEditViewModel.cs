using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;

namespace Task8.ViewModels
{
    public class GroupEditViewModel
    {
        private readonly IGroupEditModel _model;

        public GroupEditViewModel(IGroupEditModel model, IEventAggregator eventAggregator)
        {
            _model = model;
        }
    }
}
