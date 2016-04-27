using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class QuestionTypeServices : IQuestionTypeServices
    {
        private IGenericRepository _repo;
        public QuestionTypeServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<QuestionType> GetAllQuestionTypes() {
            var types = _repo.Query<QuestionType>().ToList();
            return types;
        }

    }
}
