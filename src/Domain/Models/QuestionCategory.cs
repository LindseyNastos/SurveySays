using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class QuestionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualifier { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
