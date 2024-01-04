using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Data.Entity.Generated
{
    public partial class Student : IEquatable<Student>
    {
        public bool Equals(Student other)
        {
            return StudentId == other.StudentId && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj) 
        {
            return Equals(obj as Student);
        }

        public override int GetHashCode() 
        {
            return HashCode.Combine(StudentId, FirstName, LastName);
        }
    }
}
