using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Task8.Data;
using Task8.Data.Data;
using Task8.Data.Entity.Generated;

namespace Task8.Data
{
    public class Repository : IRepository
    {
        private readonly Task6Context _context;

        public Repository(Task6Context context)
        {
            _context = context;
            _context.MigrateNotAppliedMigrations();
        }

        public IEnumerable<Course> Courses => _context.Courses.Include(c => c.Groups).ThenInclude(t => t.Teacher).Include(g => g.Groups).ThenInclude(s => s.Students);

        public IEnumerable<Teacher> Teachers => _context.Teachers.Include(t => t.Groups);

        public void Add(Teacher teacher)
        {
            ArgumentNullException.ThrowIfNull(nameof(teacher));

            _context.Teachers.Add(teacher);
        }

        public void Add(Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            _context.Groups.Add(group);
        }

        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student, nameof(student));

            _context.Students.Add(student);
        }

        public void LoadPressets()
        {
            if (Courses.IsNullOrEmpty())
            {
                string pressetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pressets.json");
                string jsonString = File.ReadAllText(pressetPath);

                var presset = JsonConvert.DeserializeObject<DataPresset>(jsonString);

                _context.Courses.AddRange(presset.Courses);

                if (Teachers.IsNullOrEmpty())
                {
                    _context.Teachers.AddRange(presset.Teachers);
                }

                _context.SaveChanges();
            }
        }

        public void Remove(Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            _context.Groups.Remove(group);
        }

        public void Remove(Student student)
        {
            ArgumentNullException.ThrowIfNull(student, nameof(student));

            _context.Students.Remove(student);
        }

        public void Remove(Teacher teacher)
        {
            ArgumentNullException.ThrowIfNull(teacher, nameof(teacher));

            _context.Teachers.Remove(teacher);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
