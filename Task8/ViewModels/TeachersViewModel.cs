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
    public class TeachersViewModel : BindableBase
    {
        private readonly ITeachersModel _teachersModel;
        private string _newTeacherName;
        private string _newTeacherSurname;
        private string _changedTeacherName;
        private string _changedTeacherSurname;
        private bool _isTeacherNameChanged = false;
        private bool _isTeacherSurnameChanged = false;

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

        public DelegateCommand SelectionChanged => new(SelectionChangedCommand);

        public DelegateCommand<string> TeacherNameChanged => new(TeacherNameChangedCommand);

        public DelegateCommand<string> TeacherSurnameChanged => new(TeacherSurnameChangedCommand);

        public DelegateCommand Update => new(UpdateCommand);

        public DelegateCommand<Teacher> Save => new(SaveCommand);

        public DelegateCommand<Teacher> Remove => new(RemoveCommand);

        public DelegateCommand Add => new(AddCommand);

        private void SelectionChangedCommand()
        {
            _isTeacherNameChanged = false;
            _isTeacherSurnameChanged = false;
        }

        private void TeacherSurnameChangedCommand(string newSurname)
        {
            _changedTeacherSurname = newSurname;
            _isTeacherSurnameChanged = true;
        }

        private void TeacherNameChangedCommand(string newName)
        {
            _changedTeacherName = newName;
            _isTeacherNameChanged = true;
        }

        private void UpdateCommand()
        {
            RaisePropertyChanged(nameof(Teachers));
        }

        private void SaveCommand(Teacher teacher)
        {
            _teachersModel.SaveChangesFor(teacher);
        }

        private void RemoveCommand(Teacher teacher)
        {
            _teachersModel.RemoveTeacher(teacher);
            RaisePropertyChanged(nameof(Teachers));
        }

        private void AddCommand()
        {
            _teachersModel.CreateTeacher(NewTeacherName, NewTeacherSurname);

            NewTeacherName = "";
            NewTeacherSurname = "";

            RaisePropertyChanged(nameof(Teachers));
            RaisePropertyChanged(nameof(NewTeacherName));
            RaisePropertyChanged(nameof(NewTeacherSurname));
        }

        #endregion
    }
}
