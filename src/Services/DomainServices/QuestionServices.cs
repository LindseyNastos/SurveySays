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
    public class QuestionServices : IQuestionServices
    {
        private IGenericRepository _repo;
        public QuestionServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Question> ListAllQuestions()
        {
            return _repo.Query<Question>().ToList();
        }

        public IList<Question> ListQuestionsByCategory(int categoryId) {
            var category = _repo.Query<QuestionCategory>()
                .Where(c => c.Id == categoryId)
                .Include(c => c.Questions)
                .FirstOrDefault();
            var questions = category.Questions.ToList();
            return questions;
        }

        public IList<Question> ListQuestionsBySurvey(int surveyId) {
            var questions = _repo.Query<QuestionSurvey>()
                .Where(s => s.SurveyId == surveyId)
                .Select(s => s.Question)
                .ToList();
            return questions;
        }

        public Question GetQuestion(int id)
        {
            return _repo.Query<Question>()
                .Where(q => q.Id == id)
                .Include(q => q.QuestionType)
                .Include(q => q.MatrixQuestions)
                .Include(q => q.AnswerOptions)
                .FirstOrDefault();
        }

        public void AddNewQuestion(Question question, int surveyId)
        {
            var join = new QuestionSurvey {
                QuestionId = question.Id,
                SurveyId = surveyId
            };
            _repo.Add<QuestionSurvey>(join);
            _repo.Add<Question>(question);
            _repo.SaveChanges();
        }

        public void EditQuestion(Question question)
        {
            var original = _repo.Query<Question>().Where(s => s.Id == question.Id).FirstOrDefault();
            original.Quest = question.Quest;
            original.QuestionType = question.QuestionType;
            original.AnswerOptions = question.AnswerOptions;
            original.MatrixQuestions = question.MatrixQuestions;
            _repo.Update<Question>(original);
        }

        public void DeleteQuestion(int id)
        {
            var question = _repo.Query<Question>().Where(s => s.Id == id).FirstOrDefault();
            _repo.Delete<Question>(question);
        }
    }
}
