﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Opt { get; set; }
        //public int QuestionId { get; set; }
        //[ForeignKey("QuestionId")]
        //public Question Question { get; set; }
    }
}
