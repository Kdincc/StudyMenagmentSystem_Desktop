using System;
using System.Collections.Generic;

namespace Task8.Data.Entity.Generated;

public partial class Group
{
    public int GroupId { get; set; }

    public int? CourseId { get; set; }

    public string Name { get; set; }

    public int? TeacherId { get; set; }

    public virtual Course Course { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Teacher Teacher { get; set; }
}
