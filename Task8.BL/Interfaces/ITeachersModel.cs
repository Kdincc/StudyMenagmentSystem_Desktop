using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ITeachersModel
    {
        public IEnumerable<Teacher> Teachers{ get; }

        public void SaveChangesFor(Teacher teacher);

        public void CreateTeacher(string name, string surname);

        public void Remove(Teacher teacher);
    }
}
