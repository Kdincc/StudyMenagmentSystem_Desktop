using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.Data
{
    public interface IRepository
    {
        public IEnumerable<Course> Courses { get; }

        public IEnumerable<Teacher> Teachers { get; }

        public void Add(Teacher teacher);

        public void Add(Group teacher);

        public void Add(Student student);

        public void Remove(Teacher teacher);

        public void Remove(Group group);

        public void Remove(Student student);

        public void LoadPressets();

        public void SaveChanges();
    }
}
