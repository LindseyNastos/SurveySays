using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Domain.Interfaces;
using Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveySays.API
{
    [Route("api/[controller]")]
    public class QuestionCategoriesController : Controller
    {
        private IQuestionCategoryServices _service;
        public QuestionCategoriesController(IQuestionCategoryServices service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _service.ListCategories();
            return Ok(categories);
        }

        // GET api/values/5
        [HttpGet("getQuestions/{categoryId}/{surveyId}")]
        public IActionResult GetQuestions(int categoryId, int surveyId)
        {
            var questions = _service.GetQuestionsByCategory(categoryId, surveyId);
            return Ok(questions);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
