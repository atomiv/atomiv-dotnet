using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Controllers
{
    [Route("api/validation-errors")]
    [ApiController]
    public class ValidationErrorsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {


            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            throw new NotImplementedException();

            // TODO: VC: Check

            /*
            if(!ModelState.IsValid)
            {
                return new ValidationProblemDetails(ModelState);
            }
            */
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
