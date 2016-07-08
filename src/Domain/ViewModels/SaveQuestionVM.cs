using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class SaveQuestionVM
    {
        public Question Question { get; set; }
        public int SurveyId { get; set; }
        public int CategoryId { get; set; }
    }
}
