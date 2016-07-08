using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveySays.API
{
    [Route("api/[controller]")]
    public class QuestionTypesController : Controller
    {
        private IQuestionTypeServices _service;
        public QuestionTypesController(IQuestionTypeServices service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var types = _service.GetAllQuestionTypes();
            return Ok(types);
        }

        // GET api/values/5
        [HttpGet("{qType}")]
        public IActionResult Get(string qType)
        {
            var questionType = _service.GetQuestionType(qType);
            return Ok(questionType);
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
