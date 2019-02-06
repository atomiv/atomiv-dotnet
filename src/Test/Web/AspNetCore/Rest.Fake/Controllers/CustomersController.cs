using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<CustomerDto> data = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                },

                new CustomerDto
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            var results = data;

            return Ok(results);
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<CustomerDto> Get(int id)
        {
            var result = data.SingleOrDefault(e => e.Id == id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 422)]
        [ProducesResponseType(500)]
        public ActionResult<CustomerDto> Post([FromBody] CustomerDto value)
        {
            if(string.IsNullOrWhiteSpace(value.FirstName))
            {
                return BadRequest();
            }

            value.Id = data.Max(e => e.Id) + 1;

            data.Add(value);

            return CreatedAtAction("Get", new { id = value.Id }, value); ;
        }

        [HttpPost("imports")]
        public ActionResult<IEnumerable<CustomerDto>> Post([FromBody] List<CustomerDto> values)
        {
            return Accepted(values);
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerDto> Put(int id, [FromBody] CustomerDto value)
        {
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
