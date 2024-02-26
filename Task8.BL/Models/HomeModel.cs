using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using Task8.BL.Interfaces;
using Task8.Data;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class HomeModel : IHomeModel
    {
        private readonly IRepository _repository;

        public HomeModel(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                if (_repository.Courses.IsNullOrEmpty())
                {
                    _repository.LoadPressets();
                }

                return _repository.Courses;
            }
        }
    }
}