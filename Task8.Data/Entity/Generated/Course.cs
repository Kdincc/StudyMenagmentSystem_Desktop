using System.Collections.Generic;

namespace Task8.Data.Entity.Generated;

public class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
