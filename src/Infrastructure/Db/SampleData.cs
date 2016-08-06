using Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using System.Security.Claims;
using Infrastructure.OptionModels;
using Microsoft.Extensions.OptionsModel;

namespace Infrastructure.Db
{
    public class SampleData
    {
        private SeedDataOptions _options;
        public SampleData(IOptions<SeedDataOptions> options)
        {
            _options = options.Value;
        }

        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            //var opts = serviceProvider.GetServices<SeedDataOptions>();

            //context.Database.EnsureDeleted();
            context.Database.Migrate();

            // Ensure Lindsey (IsAdmin)
            var lindsey = await userManager.FindByNameAsync("Lindsey.Nastos@CoderCamps.com");
            if (lindsey == null)
            {
                // create user
                lindsey = new ApplicationUser
                {
                    UserName = "Lindsey.Nastos@CoderCamps.com",
                    //UserName = opts.
                    Email = "Lindsey.Nastos@CoderCamps.com",
                    FirstName = "Lindsey",
                    LastName = "Nastos"
                };
                await userManager.CreateAsync(lindsey, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(lindsey, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }
            context.SaveChanges();

            if (!context.Campuses.Any())
            {
                context.Campuses.AddRange(
                    new Campus { Location = "Houston" },
                    new Campus { Location = "Seattle" },
                    new Campus { Location = "San Francisco" },
                    new Campus { Location = "Chicago" },
                    new Campus { Location = "Tulsa" },
                    new Campus { Location = "Dallas" },
                    new Campus { Location = "Austin" },
                    new Campus { Location = "Online" }
                );
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { Name = "ASP.NET" },
                    new Course { Name = "Coding From Scratch" },
                    new Course { Name = "Java" },
                    new Course { Name = "MEAN Stack" },
                    new Course { Name = "Ruby on Rails" }
                );
            }

            if (!context.QuestionTypes.Any())
            {
                context.QuestionTypes.AddRange(
                    new QuestionType { Type = "MultipleChoice" },
                    new QuestionType { Type = "DropdownList" },
                    new QuestionType { Type = "MatrixRating" },
                    new QuestionType { Type = "Ranking" },
                    new QuestionType { Type = "TextBox" }
                );
            }
            context.SaveChanges();



            if (!context.QuestionCategories.Any())
            {
                context.QuestionCategories.AddRange(
                    new QuestionCategory
                    {
                        Name = "Course Material"
                    },
                    new QuestionCategory
                    {
                        Name = "Instruction",
                        Qualifier = "Please fill out this section as regards your primary instructor only unless otherwise specified."
                    },
                    new QuestionCategory
                    {
                        Name = "Group Project"
                    },
                    new QuestionCategory
                    {
                        Name = "General"
                    },
                    new QuestionCategory
                    {
                        Name = "Other"
                    }
                );
            }
            context.SaveChanges();

            if (!context.Questions.Any())
            {
                context.Questions.AddRange(
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "General").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "What was the most difficult part of the camp?",
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "General").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "MultipleChoice"),
                        Quest = "Which option best describes the course overall?",
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "General").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "MultipleChoice"),
                        Quest = "Which option best describes the online course overall?",
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "General").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?"
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "Instruction").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "How could the instructors improve?"
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "Instruction").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "What did the instructors excel at?"
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "Course Material").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "Ranking"),
                        Quest = "Rank the following weeks in order of difficulty (1 being most difficult, 6 being easiest):",
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "Course Material").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "Ranking"),
                        Quest = "Rank the following modules in order of difficulty (1 being most difficult, 6 being easiest):",
                    },
                    new Question
                    {
                        QuestionCategoryId = context.QuestionCategories.FirstOrDefault(q => q.Name == "General").Id,
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "MatrixRating"),
                        Quest = "Choose the option that best fits your experience for each of the following categories:",
                    }
                );
            }
            context.SaveChanges();

            if (!context.Options.Any())
            {
                var questOne = context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the course overall?");
                questOne.AnswerOptions = new List<Option> {
                    new Option
                    {
                        Opt = "Way too difficult"
                    },
                    new Option
                    {
                        Opt = "Very challenging but doable"
                    },
                    new Option
                    {
                        Opt = "Just right"
                    },
                    new Option
                    {
                        Opt = "Too easy, I wanted more of a challenge"
                    }
                };

                var questTwo = context.Questions.FirstOrDefault(q => q.Quest == "Rank the following weeks in order of difficulty (1 being most difficult, 6 being easiest):");
                questTwo.AnswerOptions = new List<Option> {
                    new Option
                    {
                        Opt = "Week one: JavaScript"
                    },
                    new Option
                    {
                        Opt = "Week two: Angular"
                    },
                    new Option
                    {
                        Opt = "Week three: C#"
                    },
                    new Option
                    {
                        Opt = "Week four: ASP.NET/Web API"
                    },
                    new Option
                    {
                        Opt = "Week five: Security/Azure/Mobile"
                    },
                    new Option
                    {
                        Opt = "Week six: Agile"
                    }
                };

                var questThree = context.Questions.FirstOrDefault(q => q.Quest == "Rank the following modules in order of difficulty (1 being most difficult, 6 being easiest):");
                questThree.AnswerOptions = new List<Option> {
                    new Option
                    {
                        Opt = "Module one: HTML"
                    },
                    new Option
                    {
                        Opt = "Module two: CSS"
                    },
                    new Option
                    {
                        Opt = "Module three: JavaScript"
                    },
                    new Option
                    {
                        Opt = "Module four: DOM"
                    },
                    new Option
                    {
                        Opt = "Module five: jQuery/Bootstrap"
                    },
                    new Option
                    {
                        Opt = "Module six: Building Apps"
                    }
                };

                var questFour = context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the online course overall?");
                questFour.AnswerOptions = new List<Option> {
                    new Option
                    {
                        Opt = "Way too difficult"
                    },
                    new Option
                    {
                        Opt = "Very challenging but doable"
                    },
                    new Option
                    {
                        Opt = "Just right"
                    },
                    new Option
                    {
                        Opt = "Too easy, I wanted more of a challenge"
                    }
                };

                var questFive = context.Questions.FirstOrDefault(q => q.Quest == "Choose the option that best fits your experience for each of the following categories:");
                questFive.AnswerOptions = new List<Option> {
                    new Option {
                        Opt = "Absolutely true"
                    },
                    new Option {
                        Opt = "Somewhat true"
                    },
                    new Option {
                        Opt = "Maybe"
                    },
                    new Option {
                        Opt = "Don't know"
                    },
                    new Option {
                        Opt = "Somewhat false"
                    },
                    new Option {
                        Opt = "Absolutely false"
                    }
                };


                questFive.MatrixQuestions = new List<MatrixQuestion> {
                    new MatrixQuestion
                    {
                        Opt = "The instructors were invested in the students."
                    },
                    new MatrixQuestion
                    {
                        Opt = "The material was taught in an understandable way."
                    },
                    new MatrixQuestion
                    {
                        Opt = "The group project went very smoothly."
                    },
                    new MatrixQuestion
                    {
                        Opt = "The class should have covered more material."
                    },
                    new MatrixQuestion
                    {
                        Opt = "I feel confident in my skills as a developer due to this course."
                    },
                };
            }
            context.SaveChanges();

            if (!context.Surveys.Any())
            {
                context.Surveys.AddRange(
                    new Survey
                    {
                        UserId = lindsey.Id,
                        SurveyName = "Seattle .Net Troop 8",
                        Course = context.Courses.FirstOrDefault(c => c.Name == "ASP.NET"),
                        DateCreated = DateTime.UtcNow,
                        Released = false,
                        CurrentTroop = 8,
                        IsActive = true,
                        Questions = {
                            context.Questions.FirstOrDefault(q => q.Quest == "What was the most difficult part of the camp?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the course overall?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "How could the instructors improve?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "What did the instructors excel at?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Rank the following weeks in order of difficulty (1 being most difficult, 6 being easiest):"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Choose the option that best fits your experience for each of the following categories:")
                        }
                    },
                    new Survey
                    {
                        UserId = lindsey.Id,
                        SurveyName = "Online CFS #22",
                        Course = context.Courses.FirstOrDefault(c => c.Name == "Coding From Scratch"),
                        DateCreated = DateTime.UtcNow,
                        Released = false,
                        CurrentTroop = 46,
                        IsActive = true,
                        Questions = {
                            context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the online course overall?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Rank the following modules in order of difficulty (1 being most difficult, 6 being easiest):"),
                        }
                    }
                );
                context.SaveChanges();
                lindsey.Surveys.Add(context.Surveys.First(s => s.SurveyName == "Seattle .Net Troop 8"));
            }
            context.SaveChanges();
        }
    }
}
