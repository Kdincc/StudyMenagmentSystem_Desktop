using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Events;

namespace Task8.ViewModels
{
    public class CourseEditViewModel : BindableBase
    {
        private readonly ICourseEditModel _courseEditModel;
        private readonly IEventAggregator _eventAggregator;
        private Group _selectedGroup;
        private string _newGroupName;
        private bool _isToolBarButtonsActive = false;

        public CourseEditViewModel(ICourseEditModel courseEditModel, IEventAggregator eventAggregator)
        {
            _courseEditModel = courseEditModel;
            _eventAggregator = eventAggregator;
            Save = new(SaveCommand);
            Remove = new(RemoveCommand);
            Add = new(AddCommand);
            BuildDocxReport = new(BuildDocxReportCommand);
            BuildPdfReport = new(BuildPdfReportCommand);
            ImportStudents = new(ImportStudentsCommand);
            ExportStudents = new(ExportStudentsCommand);

            _eventAggregator.GetEvent<EditNavigateEvent>().Subscribe(OnNavigate);
        }

        #region Props

        public bool IsToolBarButtonsActive
        {
            get { return _isToolBarButtonsActive; }
            set { SetProperty(ref _isToolBarButtonsActive, value); }
        }

        public string NewGroupName
        {
            get { return _newGroupName; }
            set { SetProperty(ref _newGroupName, value); }
        }

        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                SetProperty(ref _selectedGroup, value);
                IsToolBarButtonsActive = SelectedGroup is not null;
                RaisePropertyChanged(nameof(IsToolBarButtonsActive));
            }
        }

        public ObservableCollection<Group> Groups => new(_courseEditModel.Groups);

        public ObservableCollection<Teacher> Teachers => new(_courseEditModel.Teachers);

        #endregion

        #region Commands

        public DelegateCommand<Group> BuildPdfReport { get; }

        public DelegateCommand<Group> BuildDocxReport { get; }

        public DelegateCommand<Group> ExportStudents { get; }

        public DelegateCommand<Group> ImportStudents { get; }

        public DelegateCommand<Group> Save { get; }

        public DelegateCommand<Group> Remove { get; }

        public DelegateCommand Add { get; }

        private void ExportStudentsCommand(Group group)
        {
            SaveFileDialog dialog = new()
            {
                Filter = "Csv file (*.csv)|*.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                _courseEditModel.ExportStudents(group, dialog.FileName);
            }
        }

        private void ImportStudentsCommand(Group group) 
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Csv file (*.csv)|*.csv"
            };

            if(dialog.ShowDialog() == true)
            {
                _courseEditModel.ImportStudents(group, dialog.FileName);
            }
        }

        private void BuildPdfReportCommand(Group group)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "PDF file (*.pdf)|*.pdf"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _courseEditModel.BuildPDFReport(saveFileDialog.FileName, group);
            }
        }

        private void BuildDocxReportCommand(Group group)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Docx file (*.docx)|*.docx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _courseEditModel.BuildDocxReport(saveFileDialog.FileName ,group);
            }
        }

        private void RemoveCommand(Group group)
        {
            _courseEditModel.RemoveGroup(group);
            RaisePropertyChanged(nameof(Groups));
        }

        private void SaveCommand(Group group)
        {
            _courseEditModel.SaveChangesFor(group);
            RaisePropertyChanged(nameof(Groups));
        }

        private void AddCommand()
        {
            _courseEditModel.CreateGroup(NewGroupName);

            NewGroupName = "";

            RaisePropertyChanged(nameof(Groups));
            RaisePropertyChanged(nameof(NewGroupName));
        }

        #endregion

        private void OnNavigate(object item)
        {
            if (item is Course)
            {
                _courseEditModel.InitCourse(item as Course);
                RaisePropertyChanged(nameof(Teachers));
                RaisePropertyChanged(nameof(Groups));
            }
        }
    }
}
