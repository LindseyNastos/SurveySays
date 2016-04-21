using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Domain.Enums;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Surveys = new List<Survey>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Course CourseTaught { get; set; }
        public Campus Location { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
