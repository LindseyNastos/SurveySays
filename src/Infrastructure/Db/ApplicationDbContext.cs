using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Domain.Models;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Db
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyToTake> SurveysToTake { get; set; }
        public DbSet<QuestionSurvey> QuestionSurveys { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet5-SurveySays-6098d324-d1ad-4192-8f7e-c0ce43808d72;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<QuestionSurvey>().HasKey(x => new { x.QuestionId, x.SurveyId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
