using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using Task8.BL.Interfaces;
using Task8.BL.Messagers;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class CourseEditModel : ICourseEditModel
    {
        private Course _currentCourse = new();
        private readonly IDocxService _docxBuilder;
        private readonly IPdfService _pdfBuilder;
        private readonly ICsvService _csvService;
        private readonly IRepositoryService _repository;

        public CourseEditModel(IRepositoryService repository, IDocxService docxBuilder, IPdfService pdfBuilder, ICsvService csvService)
        {
            _docxBuilder = docxBuilder;
            _pdfBuilder = pdfBuilder;
            _csvService = csvService;
            _repository = repository;
        }

        public IEnumerable<Group> Groups => _currentCourse.Groups;

        public IEnumerable<Teacher> Teachers => _repository.Teachers;

        public void CreateGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) 
            {
                CourseEditMessager.EmptyGroupNameMessage();

                return;
            }

            Group group = new()
            {
                Name = groupName,
                Course = _currentCourse,
                Teacher = Teachers.FirstOrDefault()
            };

            _repository.Add(group);
            _repository.SaveChanges();
        }

        public void InitCourse(Course course)
        {
            if (course is null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _currentCourse = course;
        }

        public void RemoveGroup(Group group)
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (group.Students.Count > 0)
            {
                CourseEditMessager.CantRemoveGroupMessage();
                return;
            }

            _repository.Remove(group);
            _repository.SaveChanges();
        }

        public void BuildDocxReport(string savePath, Group group)
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (string.IsNullOrEmpty(savePath))
            {
                throw new ArgumentNullException(nameof(savePath));
            }    

            _docxBuilder.WriteGroupReport(savePath, ReportBuilder.BuildGroupReport(group));

            CourseEditMessager.ReportCompleteMessage();
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public void BuildPDFReport(string savePath, Group group)
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            _pdfBuilder.WriteGroupReport(savePath, ReportBuilder.BuildGroupReport(group));

            CourseEditMessager.ReportCompleteMessage();
        }

        public void ImportStudents(Group group, string csvFilePath)
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            var results = _csvService.GetStudentsFrom(csvFilePath);

            if (results.IsInvalid)
            {
                CourseEditMessager.CsvReadingErrorMessage(results.Error.Message);

                return;
            }

            group.Students = results.Records.ToList();

            _repository.SaveChanges();
        }

        public void ExportStudents(Group group, string exportPath)
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (string.IsNullOrEmpty(exportPath))
            {
                throw new ArgumentNullException(nameof(exportPath));
            }

            _csvService.WriteStudentsTo(group.Students, exportPath);
        }

        public void ChangeGroupName(Group groupToChange, string newName)
        {
            Groups.First(g => g.GroupId == groupToChange.GroupId).Name = newName;
        }

        public void ChangeGroupTeacher(Group groupToChange, Teacher newTeacher)
        {
            Groups.First(g => g.GroupId == groupToChange.GroupId).Teacher = newTeacher;
        }
    }
}
