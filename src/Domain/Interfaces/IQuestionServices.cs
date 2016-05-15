using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IQuestionServices
    {
        void AddNewQuestion(Question question, int surveyId);
        void DeleteQuestion(int id);
        void EditQuestion(Question question);
        Question GetQuestion(int id);
        IList<Question> ListAllQuestions();
        IList<Question> ListQuestionsByCategory(int categoryId);
        IList<Question> ListQuestionsBySurvey(int surveyId);
    }
}
