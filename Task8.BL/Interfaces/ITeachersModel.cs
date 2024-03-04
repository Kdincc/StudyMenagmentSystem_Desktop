using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ITeachersModel
    {
        public IEnumerable<Teacher> Teachers { get; }

        public void SaveChanges();

        public void ChangeTeacherName(Teacher teacherToChange, string newName);

        public void ChangeTeacherSurname(Teacher teacherToChange, string newSurname);

        public bool CreateTeacher(string name, string surname);

        public void RemoveTeacher(Teacher teacher);
    }
}
