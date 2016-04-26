using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class SurveyToTakeServices : ISurveyToTakeServices
    {
        private IGenericRepository _repo;
        public SurveyToTakeServices(IGenericRepository repo)
        {
            _repo = repo;
        }
        public IList<SurveyToTake> ListAllSurveysToTake()
        {
            return _repo.Query<SurveyToTake>().ToList();
        }

        public SurveyToTake GetSurveyToTake(int id)
        {
            return _repo.Query<SurveyToTake>().Where(s => s.Id == id).FirstOrDefault();
        }

        public void AddNewSurveyToTake(SurveyToTake survey)
        {
            _repo.Add<SurveyToTake>(survey);
            _repo.SaveChanges();
        }

        public void EditSurveyToTake(SurveyToTake survey)
        {
            var original = _repo.Query<SurveyToTake>().Where(s => s.Id == survey.Id).FirstOrDefault();
            original.FirstName = survey.FirstName;
            original.LastName = survey.LastName;
            original.Anonymous = survey.Anonymous;
            original.Course = survey.Course;
            _repo.Update<SurveyToTake>(original);
        }

        public void DeleteSurveyToTake(int id)
        {
            var survey = _repo.Query<SurveyToTake>().Where(s => s.Id == id).FirstOrDefault();
            _repo.Delete<SurveyToTake>(survey);
        }
    }
}
