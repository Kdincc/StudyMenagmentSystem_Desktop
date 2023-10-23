using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> Courses { get; }

        public Course Find(int id);

        public void Add(Course entity);

        public void Remove(Course entity);

        public void SaveChanges();
    }
}
