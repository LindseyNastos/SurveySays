using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Question
    {
        public Question()
        {
            MatrixQuestions = new List<Option>();
            AnswerOptions = new List<Option>();
            QuestionSurveys = new List<QuestionSurvey>();
        }
        public int Id { get; set; }
        public string Quest { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<Option> AnswerOptions { get; set; }
        public ICollection<Option> MatrixQuestions { get; set; }
        public ICollection<QuestionSurvey> QuestionSurveys { get; set; }
    }
}
