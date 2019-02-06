using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return new List<CustomerDto>
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
        }

        [HttpGet("{id}", Name = "Get")]
        public CustomerDto Get(int id)
        {
            return new CustomerDto
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
            };
        }

        /*
        [HttpPost]
        public CustomerDto Post([FromBody] CustomerDto value)
        {
            value.Id = 3;
            return value;
        }
        */

        [HttpPost]
        public void Post([FromBody] List<CustomerDto> values)
        {

        }

        [HttpPut("{id}")]
        public CustomerDto Put(int id, [FromBody] CustomerDto value)
        {
            return value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
