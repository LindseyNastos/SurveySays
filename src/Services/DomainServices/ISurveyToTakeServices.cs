using System.Collections.Generic;
using Domain.Models;

namespace Services.DomainServices
{
    public interface ISurveyToTakeServices
    {
        void AddNewSurveyToTake(SurveyToTake survey);
        void DeleteSurveyToTake(int id);
        void EditSurveyToTake(SurveyToTake survey);
        SurveyToTake GetSurveyToTake(int id);
        IList<SurveyToTake> ListAllSurveysToTake();
    }
}