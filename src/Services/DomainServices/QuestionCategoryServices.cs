using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class QuestionCategoryServices : IQuestionCategoryServices
    {
        private IGenericRepository _repo;
        public QuestionCategoryServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<QuestionCategory> ListCategories() {
            var categories = _repo.Query<QuestionCategory>().Include(c => c.Questions).ToList();
            return categories;
        }
    }
}
