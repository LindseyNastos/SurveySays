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

        public IList<Question> GetQuestionsByCategory(int categoryId, int surveyId) {
            var surveyQuestions = (_repo.Query<Survey>()
                .Include(s => s.Questions).ThenInclude(q => q.QuestionType)
                .Include(s => s.Questions).ThenInclude(q => q.AnswerOptions)
                .Include(s => s.Questions).ThenInclude(q => q.MatrixQuestions)
                .FirstOrDefault(s => s.Id == surveyId))
                .Questions.ToList();
            var categoryQuestions = surveyQuestions.Where(q => q.QuestionCategoryId == categoryId).ToList();
            return categoryQuestions;
        }
    }
}
