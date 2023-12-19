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
    public class GroupEditViewModel : BindableBase
    {
        private readonly IGroupEditModel _model;

        public GroupEditViewModel(IGroupEditModel model, IEventAggregator eventAggregator)
        {
            _model = model;
            Save = new(SaveCommand);
            Remove = new(RemoveCommand);
            eventAggregator.GetEvent<EditNavigateEvent>().Subscribe(OnNavigate);
        }

        public ObservableCollection<Student> Students => new(_model.Students);

        private void OnNavigate(object group)
        {
            if (group is Group)
            {
                _model.InitGroup(group as Group);
                RaisePropertyChanged(nameof(Students));
            }
        }

        #region Commands

        public DelegateCommand<Student> Save { get; }

        public DelegateCommand<Student> Remove { get; }

        private void SaveCommand(Student student)
        {
            _model.SaveChangesFor(student);
        }

        private void RemoveCommand(Student student) 
        {
            _model.RemoveStudent(student);
            RaisePropertyChanged(nameof(Students));
        }

        #endregion
    }
}
