using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Survey
    {
        public Survey()
        {
            QuestionSurveys = new List<QuestionSurvey>();
        }
        public int Id { get; set; }
        public string SurveyName { get; set; }
        public string UserId { get; set; }
        public Course Course { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public int NumResponses { get; set; }
        public int NumUnseenResponses { get; set; }
        public int NumQuestions { get; set; }
        public bool Released { get; set; }
        public int CurrentTroop { get; set; }
        public bool IsActive { get; set; }

        public ICollection<QuestionSurvey> QuestionSurveys { get; set; }
    }
}
