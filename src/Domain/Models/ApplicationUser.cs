using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

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
        public string ImageUrl { get; set; }
        public Course CourseTaught { get; set; }
        public Campus Location { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }

    public class UserDto {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public Course CourseTaught { get; set; }
        public Campus Location { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
