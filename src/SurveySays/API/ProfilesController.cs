using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Domain.Interfaces;
using Domain.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveySays.API
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private IProfileServices _service;
        public ProfilesController(IProfileServices service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/johnDoe
        [HttpGet("{userName}")]
        public ApplicationUser Get(string userName)
        {
            var profile = _service.GetProfile(userName);
            return profile;
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
