using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class TeachersModel : ITeachersModel
    {
        private readonly IRepositoryService _repositoryService;

        public TeachersModel(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public IEnumerable<Teacher> Teachers => _repositoryService.Teachers;

        public void CreateTeacher(string name, string surname)
        {
            _repositoryService.Add(new Teacher { Name = name, Surname = surname });
        }

        public void Remove(Teacher teacher)
        {
            _repositoryService.Teachers.ToList().Remove(teacher);

            _repositoryService.SaveChanges();
        }

        public void SaveChangesFor(Teacher teacher)
        {
            _repositoryService.SaveChanges();
        }
    }
}
