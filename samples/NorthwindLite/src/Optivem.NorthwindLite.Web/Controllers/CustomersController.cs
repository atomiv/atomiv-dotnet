using Microsoft.AspNetCore.Mvc;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Application.Interface.Services;
using Optivem.Web.AspNetCore;
using System.Threading.Tasks;

namespace Optivem.NorthwindLite.Web.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : BaseController<ICustomerService>
    {
        public CustomersController(ICustomerService service)
            : base(service)
        {
        }

        [HttpGet(Name ="list-customers")]
        [ProducesResponseType(typeof(ListCustomersResponse), 200)]
        public async Task<ActionResult<ListCustomersResponse>> ListCustomersAsync()
        {
            var response = await Service.ListCustomersAsync();
            return Ok(response);
        }

        [HttpGet("{id}", Name = "find-customer")]
        [ProducesResponseType(typeof(FindCustomerResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindCustomerResponse>> FindCustomerAsync(int id)
        {
            var response = await Service.FindCustomerAsync(id);
            return Ok(response);
        }

        [HttpPost(Name ="create-customer")]
        [ProducesResponseType(typeof(CreateCustomerResponse), 201)]
        public async Task<ActionResult<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var response = await Service.CreateCustomerAsync(request);

            // return Created(response);

            // TODO: VC: Fix
            return CreatedAtRoute("find-customer", new { id = response.Id }, response); ;
        }
    }
}