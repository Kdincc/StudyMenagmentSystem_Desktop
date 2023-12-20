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
        private string _newStudentName;
        private string _newStudentLastName;
        private readonly ITeachersModel _teachersModel;

        public TeachersViewModel(ITeachersModel teachersModel)
        {
            _teachersModel = teachersModel;
        }

        #region Props

        public ObservableCollection<Teacher> Teachers => new(_teachersModel.Teachers);

        public string NewTeacherName
        {
            get { return _newStudentName; }
            set { _newStudentName = value; }
        }

        public string NewTeacherSurname
        {
            get { return _newStudentLastName; }
            set { _newStudentLastName = value; }
        }


        #endregion

        #region Commands

        public DelegateCommand<Student> Save { get; }

        public DelegateCommand<Student> Remove { get; }

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
            _teachersModel.CreateTeachers(NewTeacherName, NewTeacherSurname);

            NewTeacherName = "";
            NewTeacherName = "";

            RaisePropertyChanged(nameof(Teachers));
            RaisePropertyChanged(nameof(NewTeacherName));
            RaisePropertyChanged(nameof(NewTeacherName));
        }

        #endregion

    }
}
