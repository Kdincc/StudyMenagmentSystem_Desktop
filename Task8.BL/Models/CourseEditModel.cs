using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class CourseEditModel : ICourseEditModel
    {
        private Course _currentCourse = new();
        private readonly ICourseRepository _repository;

        public CourseEditModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Group> Groups => _currentCourse.Groups;

        public void BuildDocxGroupList(string path)
        {
            throw new NotImplementedException();
        }

        public void BuildPDFGroupList(string path)
        {
            throw new NotImplementedException();
        }

        public void CreateGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public void InitCourse(Course course)
        {
            _currentCourse = _repository.Find(course.CourseId);
        }

        public void RemoveGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
