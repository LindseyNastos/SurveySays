using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SurveyToTake
    {
        public SurveyToTake()
        {
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Anonymous { get; set; }
        public Course Course { get; set; }
        public Survey Survey { get; set; }
        public Guid FullGuid { get; set; }
        public string ShortGuid { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
