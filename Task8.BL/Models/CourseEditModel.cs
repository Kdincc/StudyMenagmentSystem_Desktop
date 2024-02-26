using System;
using System.Collections.Generic;
using System.Linq;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class CourseEditModel : ICourseEditModel
    {
        private Course _currentCourse = new();
        private readonly IDocxService _docxBuilder;
        private readonly IPdfService _pdfBuilder;
        private readonly ICsvService _csvService;
        private readonly Repository _repository;

        public CourseEditModel(Repository repository, IDocxService docxBuilder, IPdfService pdfBuilder, ICsvService csvService)
        {
            _docxBuilder = docxBuilder;
            _pdfBuilder = pdfBuilder;
            _csvService = csvService;
            _repository = repository;
        }

        public IEnumerable<Group> Groups => _currentCourse.Groups;

        public IEnumerable<Teacher> Teachers => _repository.Teachers;

        public Course CurrentCourse
        {
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                _currentCourse = value;
            }
        }

        public bool CreateGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                return false;
            }

            Group group = new()
            {
                Name = groupName,
                Course = _currentCourse,
                Teacher = Teachers.FirstOrDefault()
            };

            _repository.Add(group);
            _repository.SaveChanges();

            return true;
        }

        public bool RemoveGroup(Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            if (group.Students.Count > 0)
            {
                return false;
            }

            _repository.Remove(group);
            _repository.SaveChanges();

            return true;
        }

        public void BuildDocxReport(string savePath, Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));
            ArgumentNullException.ThrowIfNull(savePath, nameof(savePath));

            _docxBuilder.WriteGroupReport(savePath, ReportBuilder.BuildGroupReport(group));
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public void BuildPDFReport(string savePath, Group group)
        {
            ArgumentNullException.ThrowIfNull(savePath, nameof(savePath));
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            _pdfBuilder.WriteGroupReport(savePath, ReportBuilder.BuildGroupReport(group));
        }

        public CsvReadingResults<Student> ImportStudents(Group group, string csvFilePath)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));
            ArgumentNullException.ThrowIfNull(csvFilePath, nameof(csvFilePath));

            var results = _csvService.GetStudentsFrom(csvFilePath);

            if (results.IsInvalid)
            {
                return results;
            }

            group.Students = results.Records.ToList();

            _repository.SaveChanges();

            return results;
        }

        public void ExportStudents(Group group, string exportPath)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));
            ArgumentNullException.ThrowIfNull(group, nameof(exportPath));

            _csvService.WriteStudentsTo(group.Students, exportPath);
        }

        public void ChangeGroupName(Group groupToChange, string newName)
        {
            ArgumentNullException.ThrowIfNull(groupToChange, nameof(groupToChange));

            if (groupToChange.Name == newName)
            {
                return;
            }

            Groups.First(g => g.GroupId == groupToChange.GroupId).Name = newName;
        }

        public void ChangeGroupTeacher(Group groupToChange, Teacher newTeacher)
        {
            ArgumentNullException.ThrowIfNull(groupToChange, nameof(groupToChange));
            ArgumentNullException.ThrowIfNull(newTeacher, nameof(newTeacher));

            if (groupToChange.Teacher == newTeacher)
            {
                return;
            }

            Groups.First(g => g.GroupId == groupToChange.GroupId).Teacher = newTeacher;
        }
    }
}
