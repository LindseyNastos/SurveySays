using System.Collections.Generic;
using Domain.Models;

namespace Services.DomainServices
{
    public interface ISurveyServices
    {
        void AddNewSurvey(Survey survey);
        void DeleteSurvey(int id);
        void EditSurvey(Survey survey);
        Survey GetSurvey(int id);
        IList<Survey> ListAllSurveys();
    }
}