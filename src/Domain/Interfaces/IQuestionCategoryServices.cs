﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IQuestionCategoryServices
    {
        IList<QuestionCategory> ListCategories();
        IList<Question> GetQuestionsByCategory(int categoryId, int surveyId);
    }
}
