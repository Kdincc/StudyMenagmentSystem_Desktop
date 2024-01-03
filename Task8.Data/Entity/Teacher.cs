using System.Linq;

namespace Task8.Data.Entity.Generated
{
    public partial class Teacher
    {
        public string FullName => $"{Name} {Surname}";
    }
}
