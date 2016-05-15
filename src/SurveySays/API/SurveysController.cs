using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Domain.Models;
using Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveySays.API
{
    [Route("api/[controller]")]
    public class SurveysController : Controller
    {
        private ISurveyServices _service;
        public SurveysController(ISurveyServices service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.ListAllSurveys());
        }

        // GET api/values/5
        [HttpGet("GetBasicSurvey/{id}")]
        public IActionResult GetBasicSurvey(int id)
        {
            var survey = _service.GetSurvey(id);
            return Ok(survey);
        }

        [HttpGet("GetFullSurvey/{id}")]
        public IActionResult GetFullSurvey(int id) {
            var surveyVM = _service.GetFullSurvey(id);
            return Ok(surveyVM);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Survey survey)
        {
            if (ModelState.IsValid) {
                if (survey.Id == 0)
                {
                    _service.AddNewSurvey(survey);
                    return Created("/surveys/" + survey.Id, survey);
                }
                else {
                    _service.EditSurvey(survey);
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
            _service.DeleteSurvey(id);
        }
    }
}
