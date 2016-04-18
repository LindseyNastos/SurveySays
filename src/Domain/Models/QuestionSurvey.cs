using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class QuestionSurvey
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }
}
