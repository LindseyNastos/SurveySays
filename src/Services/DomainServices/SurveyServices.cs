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
            var surveys = _repo.Query<Survey>().Where(s => s.IsActive == true).ToList();
            foreach (var s in surveys) {
                s.DateCreated = s.DateCreated.ToLocalTime();
            }
            return surveys;
        }

        public Survey GetSurvey(int id) {
            var survey = _repo.Query<Survey>()
                .Where(s => s.Id == id)
                //.Where(s => s.IsActive == true)
                .Include(s => s.Course)
                .FirstOrDefault();
            survey.DateCreated = survey.DateCreated.ToLocalTime();
            survey.NumQuestions = (_repo.Query<QuestionSurvey>()
                .Where(s => s.SurveyId == id)
                .Select(s => s.Question))
                .Count();
            return survey;

        }

        public FullSurveyVM GetFullSurvey(int id) {
            var survey = GetSurvey(id);
            var questions = _repo.Query<QuestionSurvey>()
                .Where(s => s.SurveyId == id)
                .Select(s => s.Question)
                .ToList();

            survey.NumQuestions = questions.Count();
            survey.DateCreated = survey.DateCreated.ToLocalTime();

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
            survey.Released = false;
            survey.DateCreated = DateTime.UtcNow;
            survey.LastModified = survey.DateCreated;
            _repo.Add<Survey>(survey);
            _repo.SaveChanges();
        }

        public void EditSurvey(Survey survey) {
            var original = _repo.Query<Survey>().Where(s => s.Id == survey.Id).FirstOrDefault();
            original.SurveyName = survey.SurveyName;
            original.Course = survey.Course;
            original.LastModified = DateTime.UtcNow;
            _repo.Update<Survey>(original);
        }

        public void DeleteSurvey(int id) {
            var survey = _repo.Query<Survey>().Where(s => s.Id == id).FirstOrDefault();
            _repo.Delete<Survey>(survey);
        }
    }
}
