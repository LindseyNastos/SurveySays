using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Question
    {
        public Question()
        {
            MatrixQuestions = new List<MatrixQuestion>();
            AnswerOptions = new List<Option>();
        }
        public int Id { get; set; }
        public string Quest { get; set; }
        public bool AnswerRequired { get; set; }
        public int QuestionCategoryId { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<Option> AnswerOptions { get; set; }
        public ICollection<MatrixQuestion> MatrixQuestions { get; set; }
    }
}
