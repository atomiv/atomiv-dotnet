using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Services;
using Optivem.Web.AspNetCore;

namespace Optivem.NorthwindLite.Web.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : BaseController<ICustomerService>
    {
        public CustomerController(ICustomerService service)
            : base(service)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListCustomersResponse), 200)]
        public async Task<ActionResult<ListCustomersResponse>> ListCustomers()
        {
            var response = await Service.ListCustomersAsync();
            return Ok(response);
        }
    }
}