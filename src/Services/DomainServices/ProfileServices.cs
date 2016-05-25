using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class ProfileServices : IProfileServices
    {
        private IGenericRepository _repo;
        public ProfileServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public ApplicationUser GetProfile(string userId) {
            //change to return user dto
            var user = _repo.Query<ApplicationUser>()
                .Include(a => a.Surveys).ThenInclude(s => s.Course)
                .Include(a => a.CourseTaught)
                .Include(a => a.Location)
                .FirstOrDefault(a => a.Id == userId);
            return user;
        }

    }

    
}
