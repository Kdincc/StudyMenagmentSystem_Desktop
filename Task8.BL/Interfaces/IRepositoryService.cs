using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IRepositoryService
    {
        public IEnumerable<Course> Courses { get; }

        public IEnumerable<Teacher> Teachers { get; }

        public void Remove(Group group);

        public void Remove(Student student);

        public Course Find(int id);

        public void SaveChanges();
    }
}
