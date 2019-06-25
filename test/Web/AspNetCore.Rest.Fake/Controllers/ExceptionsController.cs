using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.RestApi.Fake.Controllers
{
    [Route("api/exceptions")]
    public class ExceptionsController
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
                BadHttpRequestException.Throw(RequestRejectionReason.InvalidContentLength, HttpMethod.Get);
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