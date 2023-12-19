using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace Task8.Data.Entity.Generated;

public partial class Student
{
    [Ignore]
    public int StudentId { get; set; }

    [Ignore]
    public int? GroupId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Ignore]
    public virtual Group Group { get; set; }
}
