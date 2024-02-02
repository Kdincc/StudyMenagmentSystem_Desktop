using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IHomeModel
    {
        public IEnumerable<Course> Courses { get; }
    }
}
