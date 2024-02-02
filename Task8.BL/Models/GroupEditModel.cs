using System;
using System.Collections.Generic;
using System.Linq;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class GroupEditModel : IGroupEditModel
    {
        private Group _currentGroup = new();
        private readonly IRepositoryService _repositoryService;

        public GroupEditModel(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public IEnumerable<Student> Students => _currentGroup.Students;

        public Group Group
        {
            set
            {
                ArgumentNullException.ThrowIfNull(nameof(value));

                _currentGroup = value;
            }
        }

        public bool CreateStudent(string name, string lastName)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            _repositoryService.Add(new Student { FirstName = name, LastName = lastName, Group = _currentGroup });
            _repositoryService.SaveChanges();

            return true;
        }

        public void RemoveStudent(Student student)
        {
            ArgumentNullException.ThrowIfNull(student, nameof(student));

            _repositoryService.Remove(student);
            _repositoryService.SaveChanges();
        }

        public void ChangeStudentName(Student studentToChange, string newName)
        {
            ArgumentNullException.ThrowIfNull(studentToChange, nameof(studentToChange));

            Students.First(s => s.StudentId == studentToChange.StudentId).FirstName = newName;
        }

        public void ChangeStudentLastName(Student studentToChange, string newLastName)
        {
            ArgumentNullException.ThrowIfNull(studentToChange, nameof(studentToChange));

            Students.First(s => s.StudentId == studentToChange.StudentId).LastName = newLastName;
        }

        public void SaveChanges()
        {
            _repositoryService.SaveChanges();
        }
    }
}
