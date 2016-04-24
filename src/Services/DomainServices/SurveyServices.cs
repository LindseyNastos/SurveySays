using Domain.Models;
using Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _repo.Query<Survey>().Where(s => s.Id == id).FirstOrDefault();
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
