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
        private string _newTeacherName;
        private string _newTeacherSurname;
        private readonly ITeachersModel _teachersModel;

        public TeachersViewModel(ITeachersModel teachersModel)
        {
            _teachersModel = teachersModel;
            Save = new(SaveCommand);
            Add = new(AddCommand);
            Remove = new(RemoveCommand);
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

        public DelegateCommand<Teacher> Save { get; }

        public DelegateCommand<Teacher> Remove { get; }

        public DelegateCommand Add { get; }

        private void SaveCommand(Teacher teacher)
        {
            _teachersModel.SaveChangesFor(teacher);
        }

        private void RemoveCommand(Teacher teacher)
        {
            _teachersModel.Remove(teacher);
            RaisePropertyChanged(nameof(Teachers));
        }

        private void AddCommand()
        {
            _teachersModel.CreateTeacher(NewTeacherName, NewTeacherSurname);

            NewTeacherName = "";
            NewTeacherName = "";

            RaisePropertyChanged(nameof(Teachers));
            RaisePropertyChanged(nameof(NewTeacherName));
            RaisePropertyChanged(nameof(NewTeacherName));
        }

        #endregion

    }
}
