using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
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
