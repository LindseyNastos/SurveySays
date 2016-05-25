using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class CourseServices : ICourseServices
    {
        private IGenericRepository _repo;
        public CourseServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Course> GetAllCourses() {
            var courses = _repo.Query<Course>().ToList();
            return courses;
        }

    }
}
