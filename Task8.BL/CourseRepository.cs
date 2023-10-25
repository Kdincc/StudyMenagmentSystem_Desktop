using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Data;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Task6Context _context;

        public CourseRepository(Task6Context context) 
        {
            _context = context;
        }

        public IEnumerable<Course> Courses => _context.Courses.Include(c => c.Groups).ThenInclude(g => g.Students);

        public void Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public Course Find(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.CourseId == id);
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
