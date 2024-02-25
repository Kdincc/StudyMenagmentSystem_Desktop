using CsvHelper.Configuration.Attributes;
using System;

namespace Task8.Data.Entity.Generated;

public class Student : IEquatable<Student>
{
    [Ignore]
    public int StudentId { get; set; }

    [Ignore]
    public int? GroupId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Ignore]
    public virtual Group Group { get; set; }

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
