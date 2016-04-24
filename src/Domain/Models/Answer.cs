using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Ans { get; set; }
        public int Value { get; set; }
        public int QuestionId { get; set; }
    }
}
