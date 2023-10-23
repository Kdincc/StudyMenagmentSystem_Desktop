using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class HomeModel : IHomeModel
    {
        private readonly ICourseRepository _repository;

        public HomeModel(ICourseRepository repository) 
        {
            _repository = repository;
        }

        public IEnumerable<Course> Courses => _repository.Courses;
    }
}
