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

            if (!context.Campuses.Any()) {
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
                    new QuestionType { Type = "Multiple Choice" },
                    new QuestionType { Type = "Dropdown List" },
                    new QuestionType { Type = "Matrix Rating" },
                    new QuestionType { Type = "Ranking" },
                    new QuestionType { Type = "TextBox" }
                );
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
                        DateCreated = DateTime.Now
                    },
                    new Survey
                    {
                        UserId = lindsey.Id,
                        SurveyName = "Online CFS #22",
                        Course = context.Courses.FirstOrDefault(c => c.Name == "Coding From Scratch"),
                        DateCreated = DateTime.Now
                    }
                );
                context.SaveChanges();
                lindsey.Surveys.Add(context.Surveys.First(s => s.SurveyName == "Seattle .Net Troop 8"));
            }

            context.SaveChanges();

            if (!context.Questions.Any())
            {
                context.Questions.AddRange(
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "What was the most difficult part of the camp?"
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "Multiple Choice"),
                        Quest = "Which option best describes the course overall?",
                        AnswerOptions = {
                            new Option {
                                Opt = "Way too difficult"
                            },
                            new Option {
                                Opt = "Very challenging but doable"
                            },
                            new Option {
                                Opt = "Just right"
                            },
                            new Option {
                                Opt = "Too easy, I wanted more of a challenge"
                            }
                        }
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?"
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "How could the instructors improve?"
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "Multiple Choice"),
                        Quest = "Which best describes the apartment/living quarters overall when you first arrived?",
                        AnswerOptions = {
                            new Option {
                                Opt = "Spotless"
                            },
                            new Option {
                                Opt = "Fairly clean"
                            },
                            new Option {
                                Opt = "Fine"
                            },
                            new Option {
                                Opt = "A little gross"
                            },
                            new Option {
                                Opt = "Filthy"
                            }
                        }
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "What did you appreciate about the accommodations?"
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "What could be improved about the accommodations?"
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "TextBox"),
                        Quest = "What did the instructors excel at?"
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "Ranking"),
                        Quest = "Rank the following in order of difficulty (1 being most difficult, 6 being easiest):",
                        AnswerOptions = {
                            new Option {
                                Opt = "Week one: JavaScript"
                            },
                            new Option {
                                Opt = "Week two: Angular"
                            },
                            new Option {
                                Opt = "Week three: C#"
                            },
                            new Option {
                                Opt = "Week four: ASP.NET/Web API"
                            },
                            new Option {
                                Opt = "Week five: Security/Azure/Mobile"
                            },
                            new Option {
                                Opt = "Week six: Agile"
                            }
                        }
                    },
                    new Question
                    {
                        QuestionType = context.QuestionTypes.FirstOrDefault(q => q.Type == "Matrix Rating"),
                        Quest = "Choose the option that best fits your experience for each of the following categories:",
                        MatrixQuestions = {
                            new Option {
                                Opt = "The instructors were invested in the students."
                            },
                            new Option {
                                Opt = "The material was taught in an understandable way."
                            },
                            new Option {
                                Opt = "The group project went very smoothly."
                            },
                            new Option {
                                Opt = "The class should have covered more material."
                            },
                            new Option {
                                Opt = "I feel confident in my skills as a developer due to this course."
                            },
                        },
                        AnswerOptions = {
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
                        }
                    }
                );
            }
            context.SaveChanges();

            if (!context.QuestionSurveys.Any())
            {
                context.QuestionSurveys.AddRange(
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "Which best describes the apartment/living quarters overall when you first arrived?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "What did you appreciate about the accommodations?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "What could be improved about the accommodations?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "What was the most difficult part of the camp?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the course overall?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "Rank the following in order of difficulty (1 being most difficult, 6 being easiest):").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Seattle .Net Troop 8").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "Choose the option that best fits your experience for each of the following categories:").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Online CFS #22").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "What was the most difficult part of the camp?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Online CFS #22").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the course overall?").Id
                },
                new QuestionSurvey
                {
                    SurveyId = context.Surveys.FirstOrDefault(s => s.SurveyName == "Online CFS #22").Id,
                    QuestionId = context.Questions.FirstOrDefault(q => q.Quest == "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?").Id
                }
            );
            }
            context.SaveChanges();

            if (!context.QuestionCategories.Any())
            {
                context.QuestionCategories.AddRange(
                    new QuestionCategory
                    {
                        Name = "Housing",
                        Qualifier = "If your housing was not arranged by CoderCamps, please skip this section.",
                        Questions = new List<Question> {
                            context.Questions.FirstOrDefault(q => q.Quest == "What did you appreciate about the accommodations?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "What could be improved about the accommodations?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Which best describes the apartment/living quarters overall when you first arrived?")
                        }
                    },
                    new QuestionCategory
                    {
                        Name = "Course Material",
                        Questions = new List<Question> {
                            context.Questions.FirstOrDefault(q => q.Quest == "Rank the following in order of difficulty (1 being most difficult, 6 being easiest):")
                        }
                    },
                    new QuestionCategory
                    {
                        Name = "Instruction",
                        Qualifier = "Please fill out this section as regards your primary instructor only unless otherwise specified.",
                        Questions = new List<Question> {
                            context.Questions.FirstOrDefault(q => q.Quest == "How could the instructors improve?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "What did the instructors excel at?")
                        }
                    },
                    new QuestionCategory {
                        Name = "Group Project"
                    },
                    new QuestionCategory {
                        Name = "General",
                        Questions = new List<Question> {
                            context.Questions.FirstOrDefault(q => q.Quest == "What was the most difficult part of the camp?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Which option best describes the course overall?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?"),
                            context.Questions.FirstOrDefault(q => q.Quest == "Choose the option that best fits your experience for each of the following categories:")
                        }
                    },
                    new QuestionCategory {
                        Name = "Other"
                    }
                );
            }
            context.SaveChanges();
        }

    }
}
