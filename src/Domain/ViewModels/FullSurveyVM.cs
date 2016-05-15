using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class FullSurveyVM
    {
        public Survey Survey { get; set; }
        public IList<Question> Questions { get; set; }
    }
}
