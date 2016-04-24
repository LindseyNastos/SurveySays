using Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class AnswerServices
    {
        private IGenericRepository _repo;
        public AnswerServices(IGenericRepository repo)
        {
            _repo = repo;
        }
    }
}
