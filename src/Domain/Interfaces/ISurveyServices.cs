using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISurveyServices
    {
        void AddNewSurvey(Survey survey);
        void DeleteSurvey(int id);
        void EditSurvey(Survey survey);
        Survey GetSurvey(int id);
        IList<Survey> ListAllSurveys();
        FullSurveyVM GetFullSurvey(int id);
    }
}
