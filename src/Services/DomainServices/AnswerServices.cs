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
    public class AnswerServices : IAnswerServices
    {
        private IGenericRepository _repo;
        public AnswerServices(IGenericRepository repo)
        {
            _repo = repo;
        }
        public IList<Answer> GetAnswersForCreatedSurvey(int surveyId) {
            var surveysTaken = _repo.Query<SurveyToTake>()
                .Include(s => s.Answers)
                .Where(s => s.Survey.Id == surveyId)
                .ToList();
            var answers = new List<Answer>();
            foreach (var survey in surveysTaken) {
                answers.AddRange(survey.Answers);
            }
            return answers;
        }

        public ICollection<Answer> GetAnswersForTakenSurvey(int surveyToTakeId) {
            var surveyTaken = _repo.Query<SurveyToTake>()
                .Include(s => s.Answers)
                .FirstOrDefault(s => s.Id == surveyToTakeId);
            return surveyTaken.Answers;
        }
    }
}
