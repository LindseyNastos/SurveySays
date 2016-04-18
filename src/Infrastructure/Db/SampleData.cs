﻿using Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using System.Security.Claims;
using Domain.Enums;

namespace Infrastructure.Db
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            context.Database.Migrate();

            // Ensure Lindsey (IsAdmin)
            var lindsey = await userManager.FindByNameAsync("Lindsey.Nastos@CoderCamps.com");
            if (lindsey == null)
            {
                // create user
                lindsey = new ApplicationUser
                {
                    UserName = "Lindsey.Nastos@CoderCamps.com",
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

            if (!context.Surveys.Any())
            {
                context.Surveys.AddRange(
                    new Survey
                    {
                        UserId = lindsey.Id,
                        SurveyName = "Seattle .Net Troop 8",
                        Course = Course.ASPNET
                    },
                    new Survey
                    {
                        UserId = lindsey.Id,
                        SurveyName = "Online CFS #22",
                        Course = Course.CFS
                    }
                );
            }
            
                context.SaveChanges();

            if (!context.Questions.Any())
            {
                context.Questions.AddRange(
                    new Question
                    {
                        QuestionType = QuestionType.TextBox,
                        Quest = "What was the most difficult part of the camp?",
                    },
                    new Question
                    {
                        QuestionType = QuestionType.MultipleChoice,
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
                        QuestionType = QuestionType.TextBox,
                        Quest = "How did the camp compare to your expectations before you started the course? Did you get what you expected out of it?"
                    },
                    new Question
                    {
                        QuestionType = QuestionType.TextBox,
                        Quest = "How could the instructors improve?"
                    },
                    new Question
                    {
                        QuestionType = QuestionType.TextBox,
                        Quest = "What did the instructors excel at?"
                    },
                    new Question
                    {
                        QuestionType = QuestionType.Ranking,
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
                        QuestionType = QuestionType.MatrixRating,
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
                                Opt = "Absolutely True"
                            },
                            new Option {
                                Opt = "Somewhat True"
                            },
                            new Option {
                                Opt = "Maybe"
                            },
                            new Option {
                                Opt = "Don't know"
                            },
                            new Option {
                                Opt = "Somewhat False"
                            },
                            new Option {
                                Opt = "Absolutely False"
                            }
                        }
                    }
                );
            }
            context.SaveChanges();

            context.QuestionSurveys.AddRange(
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
            context.SaveChanges();
        }
    }
}
