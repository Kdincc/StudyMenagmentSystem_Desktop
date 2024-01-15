using iText.Forms.Fields.Merging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.BL.Messagers;
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
         
        public void CreateStudent(string name, string lastName)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName)) 
            {
                GroupEditMessager.EmptyStudentNameMessage();

                return;
            }

            _repositoryService.Add(new Student { FirstName = name, LastName = lastName, Group = _currentGroup });
            _repositoryService.SaveChanges();
        }

        public void InitGroup(Group group)
        {
            if (group is null) 
            {
                throw new ArgumentNullException(nameof(group));
            }

            _currentGroup = group;
        }

        public void RemoveStudent(Student student)
        {
            if (student is null) 
            {
                throw new ArgumentNullException(nameof(student));
            }

            _repositoryService.Remove(student);
            _repositoryService.SaveChanges();
        }

        public void ChangeStudentName(Student studentToChange, string newName)
        {
            Students.First(s => s.StudentId == studentToChange.StudentId).FirstName = newName;
        }

        public void ChangeStudentLastName(Student studentToChange, string newLastName)
        {
            Students.First(s => s.StudentId == studentToChange.StudentId).LastName = newLastName;
        }

        public void SaveChanges()
        {
            _repositoryService.SaveChanges();
        }
    }
}
