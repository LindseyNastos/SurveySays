using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveySays.API
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private IQuestionServices _service;
        public QuestionsController(IQuestionServices service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allQuestions = _service.ListAllQuestions();
            return Ok(allQuestions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var question = _service.GetQuestion(id);
            return Ok(question);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SaveQuestionVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Question.Id == 0)
                {
                    _service.AddNewQuestion(vm.Question, vm.SurveyId, vm.CategoryId);
                    return Created("/surveys/" + vm.Question.Id, vm.Question);
                }
                else
                {
                    _service.EditQuestion(vm.Question);
                }
            }
            return HttpBadRequest(ModelState);
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
            _service.DeleteQuestion(id);
        }
    }
}
