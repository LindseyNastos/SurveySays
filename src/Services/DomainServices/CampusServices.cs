using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class CampusServices : ICampusServices
    {
        private IGenericRepository _repo;
        public CampusServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Campus> GetAllCampuses() {
            var campuses = _repo.Query<Campus>().ToList();
            return campuses;
        }

    }
}
