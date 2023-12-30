using System;
using System.Collections.Generic;
using System.IO;
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

            _currentCourse.Groups.Add(group);
            _repository.SaveChanges();
        }

        public void InitCourse(Course course)
        {
            _currentCourse = course;
        }

        public void RemoveGroup(Group group)
        {
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
            _docxBuilder.BuidGroupReport(savePath, _currentCourse.Name, group);

            CourseEditMessager.ReportCompleteMessage();
        }

        public void SaveChangesFor(Group group)
        {
            _repository.SaveChanges();
        }

        public void BuildPDFReport(string savePath, Group group)
        {
            _pdfBuilder.BuidGroupReport(savePath, _currentCourse.Name, group);

            CourseEditMessager.ReportCompleteMessage();
        }

        public void ImportStudents(Group group, string csvFilePath)
        {
            var results = _csvService.GetStudentsFrom(csvFilePath);

            if(results.Error != null) 
            {
                CourseEditMessager.CsvReadingErrorMessage();

                return;
            }

            group.Students = results.Records.ToList();

            _repository.SaveChanges();
        }

        public void ExportStudents(Group group, string exportPath)
        {
            _csvService.WriteStudentsTo(group.Students, exportPath);
        }
    }
}
