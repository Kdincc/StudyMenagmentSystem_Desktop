using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Events;

namespace Task8.ViewModels
{
    public class GroupEditViewModel : BindableBase
    {
        private readonly IGroupEditModel _model;
        private string _newStudentName;
        private string _newStudentLastName;
        private string _changedStudentName;
        private string _changedStudentLastName;
        private bool _isStudentNameChanged = false;
        private bool _isStudentLastNameChanged = false;

        public GroupEditViewModel(IGroupEditModel model, IEventAggregator eventAggregator)
        {
            _model = model;

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

        public DelegateCommand SelectionChanged => new(SelectionChangedCommand);

        public DelegateCommand<string> StudentLastNameChanged => new(StudentLastNameChangedCommand);

        public DelegateCommand<string> StudentNameChanged => new(StudentNameChangedCommand);

        public DelegateCommand Update => new(UpdateCommand);

        public DelegateCommand<Student> Save => new(SaveCommand);

        public DelegateCommand<Student> Remove => new(RemoveCommand);

        public DelegateCommand Add => new(AddCommand);

        private void SelectionChangedCommand()
        {
            _isStudentLastNameChanged = false;
            _isStudentNameChanged = false;
        }

        private void StudentLastNameChangedCommand(string newLastName)
        {
            _isStudentLastNameChanged = true;
            _changedStudentLastName = newLastName;
        }

        private void StudentNameChangedCommand(string newName)
        {
            _isStudentNameChanged = true;
            _changedStudentName = newName;
        }

        private void UpdateCommand()
        {
            RaisePropertyChanged(nameof(Students));
        }

        private void SaveCommand(Student student)
        {
            if(_isStudentNameChanged)
            {
                _model.ChangeStudentName(student, _changedStudentName);
            }

            if(_isStudentLastNameChanged) 
            {
                _model.ChangeStudentLastName(student, _changedStudentLastName);
            }

            _model.SaveChanges();

            RaisePropertyChanged(nameof(Students));
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
