using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Task8.BL.Interfaces;
using Task8.Data.Data;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class RepositoryService : IRepositoryService
    {
        private readonly Task6Context _context;

        public RepositoryService(Task6Context context) 
        {
            _context = context;
        }

        public IEnumerable<Course> Courses => _context.Courses.Include(c => c.Groups).ThenInclude(t => t.Teacher).Include(g => g.Groups).ThenInclude(s => s.Students);

        public IEnumerable<Teacher> Teachers => _context.Teachers.Include(t => t.Groups);

        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        public void Add(Group teacher)
        {
            _context.Groups.Add(teacher);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Remove(Group group)
        {
            _context.Groups.Remove(group);
        }

        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }

        public void Remove(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
