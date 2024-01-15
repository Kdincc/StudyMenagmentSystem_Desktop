using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IGroupEditModel
    {
        public IEnumerable<Student> Students { get; }

        public void InitGroup(Group group);

        public void CreateStudent(string name, string lastName);

        public void RemoveStudent(Student group);

        public void ChangeStudentName(Student studentToChange,  string newName);

        public void ChangeStudentLastName(Student studentToChange, string newLastName);

        public void SaveChanges();
    }
}
