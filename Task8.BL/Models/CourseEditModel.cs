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
        private readonly ICourseEditMessager _messager;
        private readonly IDocxService _docxBuilder;
        private readonly IPDFService _pdfBuilder;
        private readonly ICsvService _csvService;
        private readonly IRepositoryService _repository;

        public CourseEditModel(IRepositoryService repository, ICourseEditMessager messager, IDocxService docxBuilder, IPDFService pdfBuilder, ICsvService csvService)
        {
            _messager = messager;
            _docxBuilder = docxBuilder;
            _pdfBuilder = pdfBuilder;
            _csvService = csvService;
            _repository = repository;
        }

        public IEnumerable<Group> Groups => _currentCourse.Groups;

        public IEnumerable<Teacher> Teachers => _repository.Teachers;

        public void CreateGroup(string groupName)
        {
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
            _currentCourse = _repository.Find(course.CourseId);
        }

        public void RemoveGroup(Group group)
        {
            if (group.Students.Count > 0)
            {
                _messager.CantRemoveGroupMessage();
                return;
            }

            _repository.Remove(group);
            _repository.SaveChanges();
        }

        public void BuildDocxReport(string savePath, Group group)
        {
            _docxBuilder.BuidGroupReport(savePath, _currentCourse.Name, group);

            _messager.ReportCompleteMessage();
        }

        public void SaveChangesFor(Group group)
        {
            _repository.SaveChanges();
        }

        public void BuildPDFReport(string savePath, Group group)
        {
            _pdfBuilder.BuidGroupReport(savePath, _currentCourse.Name, group);

            _messager.ReportCompleteMessage();
        }

        public void ImportStudents(Group group, string csvFilePath)
        {
            var results = _csvService.GetStudentsFrom(csvFilePath);

            if(results.Error != null) 
            {
                _messager.CsvReadingErrorMessage();

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
