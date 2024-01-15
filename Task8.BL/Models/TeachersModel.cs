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
    public class TeachersModel : ITeachersModel
    {
        private readonly IRepositoryService _repositoryService;

        public TeachersModel(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public IEnumerable<Teacher> Teachers => _repositoryService.Teachers;

        public void ChangeTeacherName(Teacher teacherToChange, string newName)
        {
            Teachers.First(t => t.TeacherId == teacherToChange.TeacherId).Name = newName;
        }

        public void ChangeTeacherSurname(Teacher teacherToChange, string newSurname)
        {
            Teachers.First(t => t.TeacherId == teacherToChange.TeacherId).Surname = newSurname;
        }

        public void CreateTeacher(string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                TeachersMessager.EmptyTeacherNameMessage();

                return;
            }

            _repositoryService.Add(new Teacher { Name = name, Surname = surname });

            _repositoryService.SaveChanges();
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (teacher is null) 
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            _repositoryService.Remove(teacher);

            _repositoryService.SaveChanges();
        }

        public void SaveChanges()
        {
            _repositoryService.SaveChanges();
        }
    }
}
