using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Db;
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

        public IList<Question> ListAllQuestion()
        {
            return _repo.Query<Question>().ToList();
        }

        public Question GetQuestion(int id)
        {
            return _repo.Query<Question>().Where(s => s.Id == id).FirstOrDefault();
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
