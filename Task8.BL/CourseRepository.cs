using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class CourseRepository : ICourseRepository
    {
        public IEnumerable<Course> Courses => throw new NotImplementedException();

        public void Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public Course Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Course entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
