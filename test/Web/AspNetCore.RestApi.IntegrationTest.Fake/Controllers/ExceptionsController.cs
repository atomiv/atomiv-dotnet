using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Controllers
{
    [Route("api/exceptions")]
    public class ExceptionsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id == 500)
            {
                throw new Exception("This is some exception");
            }
            else if (id == 400)
            {
                return BadRequest();
            }

            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}