using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
         
        public void CreateStudent(string name, string lastName)
        {
            _currentGroup.Students.Add(new Student { FirstName = name, LastName = lastName, Group = _currentGroup });
            _repositoryService.SaveChanges();
        }

        public void InitGroup(Group group)
        {
            if (group !=  null) 
            {
                _currentGroup = group;
            }
        }

        public void RemoveStudent(Student student)
        {
            _repositoryService.Remove(student);
            _repositoryService.SaveChanges();
        }

        public void SaveChangesFor(Student student)
        {
            _repositoryService.SaveChanges();
        }
    }
}
