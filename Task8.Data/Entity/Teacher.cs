using System.Linq;

namespace Task8.Data.Entity.Generated
{
    public partial class Teacher
    {
        public string FullName => $"{Name} {Surname}";

        public Teacher(Teacher teacher)
        {
            Name = teacher.Name;
            Surname = teacher.Surname;
            TeacherId = teacher.TeacherId;
            Groups = teacher.Groups.ToList();
        }

        public Teacher() 
        {
        }
    }
}
