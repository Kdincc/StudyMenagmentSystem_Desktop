using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ChangeTeacherName(Teacher teacherToChange, string newName)
        {
            ArgumentNullException.ThrowIfNull(teacherToChange, nameof(teacherToChange));

            Teachers.First(t => t.TeacherId == teacherToChange.TeacherId).Name = newName;
        }

        public void ChangeTeacherSurname(Teacher teacherToChange, string newSurname)
        {
            ArgumentNullException.ThrowIfNull(teacherToChange, nameof(teacherToChange));

            Teachers.First(t => t.TeacherId == teacherToChange.TeacherId).Surname = newSurname;
        }

        public bool CreateTeacher(string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            _repositoryService.Add(new Teacher { Name = name, Surname = surname });

            _repositoryService.SaveChanges();

            return true;
        }

        public void RemoveTeacher(Teacher teacher)
        {
            ArgumentNullException.ThrowIfNull(teacher, nameof(teacher));

            _repositoryService.Remove(teacher);

            _repositoryService.SaveChanges();
        }

        public void SaveChanges()
        {
            _repositoryService.SaveChanges();
        }
    }
}
