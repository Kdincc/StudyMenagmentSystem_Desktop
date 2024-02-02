using System.Collections.Generic;

namespace Task8.Data.Entity.Generated;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
