using System;

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
            if (obj is Student)
            {
                return Equals(obj as Student);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudentId, FirstName, LastName);
        }
    }
}
