using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IGroupEditModel
    {
        public Group Group { set; }

        public IEnumerable<Student> Students { get; }

        public bool CreateStudent(string name, string lastName);

        public void RemoveStudent(Student group);

        public void ChangeStudentName(Student studentToChange, string newName);

        public void ChangeStudentLastName(Student studentToChange, string newLastName);

        public void SaveChanges();
    }
}
