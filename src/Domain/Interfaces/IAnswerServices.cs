using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAnswerServices
    {
        IList<Answer> GetAnswersForCreatedSurvey(int surveyId);
        ICollection<Answer> GetAnswersForTakenSurvey(int surveyToTakeId);
    }
}
