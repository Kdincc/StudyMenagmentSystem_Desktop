using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class TeachersModel : ITeachersModel
    {
        public IEnumerable<Teacher> Teachers => throw new NotImplementedException();

        public void Remove(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesFor(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
