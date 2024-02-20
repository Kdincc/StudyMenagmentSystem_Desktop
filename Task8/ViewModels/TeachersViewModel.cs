using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Messagers;

namespace Task8.ViewModels
{
    public class TeachersViewModel : BindableBase
    {
        private readonly ITeachersModel _teachersModel;
        private string _newTeacherName;
        private string _newTeacherSurname;
        private string _changedTeacherName;
        private string _changedTeacherSurname;

        public TeachersViewModel(ITeachersModel teachersModel)
        {
            _teachersModel = teachersModel;
        }

        #region Props

        public ObservableCollection<Teacher> Teachers => new(_teachersModel.Teachers);

        public string NewTeacherName
        {
            get { return _newTeacherName; }
            set { _newTeacherName = value; }
        }

        public string NewTeacherSurname
        {
            get { return _newTeacherSurname; }
            set { _newTeacherSurname = value; }
        }


        #endregion

        #region Commands

        public DelegateCommand<string> TeacherNameChanged => new(TeacherNameChangedCommand);

        public DelegateCommand<string> TeacherSurnameChanged => new(TeacherSurnameChangedCommand);

        public DelegateCommand Update => new(UpdateCommand);

        public DelegateCommand<Teacher> Save => new(SaveCommand);

        public DelegateCommand<Teacher> Remove => new(RemoveCommand);

        public DelegateCommand Add => new(AddCommand);

        private void TeacherSurnameChangedCommand(string newSurname)
        {
            _changedTeacherSurname = newSurname;
        }

        private void TeacherNameChangedCommand(string newName)
        {
            _changedTeacherName = newName;
        }

        private void UpdateCommand()
        {
            RaisePropertyChanged(nameof(Teachers));
        }

        private void SaveCommand(Teacher teacher)
        {
            if (_changedTeacherName is not null)
            {
                _teachersModel.ChangeTeacherName(teacher, _changedTeacherName);
            }

            if (_changedTeacherSurname is not null)
            {
                _teachersModel.ChangeTeacherSurname(teacher, _changedTeacherSurname);
            }

            _teachersModel.SaveChanges();
            RaisePropertyChanged(nameof(Teachers));
        }

        private void RemoveCommand(Teacher teacher)
        {
            _teachersModel.RemoveTeacher(teacher);
            RaisePropertyChanged(nameof(Teachers));
        }

        private void AddCommand()
        {
            if (!_teachersModel.CreateTeacher(NewTeacherName, NewTeacherSurname))
            {
                TeachersMessager.EmptyTeacherNameMessage();
            }

            NewTeacherName = "";
            NewTeacherSurname = "";

            RaisePropertyChanged(nameof(Teachers));
            RaisePropertyChanged(nameof(NewTeacherName));
            RaisePropertyChanged(nameof(NewTeacherSurname));
        }

        #endregion
    }
}
