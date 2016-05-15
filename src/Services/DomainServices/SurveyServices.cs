using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Domain.ViewModels;

namespace Services.DomainServices
{
    public class SurveyServices : ISurveyServices
    {
        private IGenericRepository _repo;
        public SurveyServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Survey> ListAllSurveys() {
            return _repo.Query<Survey>().ToList();
        }

        public Survey GetSurvey(int id) {
            return _repo.Query<Survey>().Where(s => s.Id == id).Include(s => s.Course).FirstOrDefault();
        }

        public FullSurveyVM GetFullSurvey(int id) {
            var survey = GetSurvey(id);
            var questions = _repo.Query<QuestionSurvey>()
                .Where(s => s.SurveyId == id)
                .Select(s => s.Question)
                .ToList();

            var questionDetails = new List<Question>();

            foreach (var question in questions) {
                var quest = _repo.Query<Question>()
                    .Where(q => q.Id == question.Id)
                    .Include(q => q.AnswerOptions)
                    .Include(q => q.MatrixQuestions)
                    .Include(q => q.QuestionType)
                    .FirstOrDefault();
                questionDetails.Add(quest);
            }

            var vm = new FullSurveyVM
            {
                Survey = survey,
                Questions = questionDetails
            };
            return vm;
        }

        public void AddNewSurvey(Survey survey) {
            _repo.Add<Survey>(survey);
            _repo.SaveChanges();
        }

        public void EditSurvey(Survey survey) {
            var original = _repo.Query<Survey>().Where(s => s.Id == survey.Id).FirstOrDefault();
            original.SurveyName = survey.SurveyName;
            original.Course = survey.Course;
            _repo.Update<Survey>(original);
        }

        public void DeleteSurvey(int id) {
            var survey = _repo.Query<Survey>().Where(s => s.Id == id).FirstOrDefault();
            _repo.Delete<Survey>(survey);
        }
    }
}
