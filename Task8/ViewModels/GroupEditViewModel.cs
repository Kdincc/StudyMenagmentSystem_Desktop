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
        private string _newStudentName;
        private string _newStudentLastName;
        private readonly IGroupEditModel _model;

        public GroupEditViewModel(IGroupEditModel model, IEventAggregator eventAggregator)
        {
            _model = model;
            Save = new(SaveCommand);
            Remove = new(RemoveCommand);
            Add = new(AddCommand);
            eventAggregator.GetEvent<EditNavigateEvent>().Subscribe(OnNavigate);
        }

        #region Props

        public ObservableCollection<Student> Students => new(_model.Students);

        public string NewStudentName
        {
            get { return _newStudentName; }
            set { _newStudentName = value; }
        }

        public string NewStudentLastName
        {
            get { return _newStudentLastName; }
            set { _newStudentLastName = value; }
        }


        #endregion

        #region Commands

        public DelegateCommand<Student> Save { get; }

        public DelegateCommand<Student> Remove { get; }

        public DelegateCommand Add { get; }

        private void SaveCommand(Student student)
        {
            _model.SaveChangesFor(student);
        }

        private void RemoveCommand(Student student) 
        {
            _model.RemoveStudent(student);
            RaisePropertyChanged(nameof(Students));
        }

        private void AddCommand()
        {
            _model.CreateStudent(NewStudentName, NewStudentLastName);

            NewStudentName = "";
            NewStudentLastName = "";

            RaisePropertyChanged(nameof(Students));
            RaisePropertyChanged(nameof(NewStudentName));
            RaisePropertyChanged(nameof(NewStudentLastName));
        }

        #endregion

        private void OnNavigate(object group)
        {
            if (group is Group)
            {
                _model.InitGroup(group as Group);
                RaisePropertyChanged(nameof(Students));
            }
        }

    }
}
