using System.Collections.Generic;
using Domain.Models;

namespace Services.DomainServices
{
    public interface IQuestionServices
    {
        void AddNewQuestion(Question question, int surveyId);
        void DeleteQuestion(int id);
        void EditQuestion(Question question);
        Question GetQuestion(int id);
        IList<Question> ListAllQuestion();
    }
}