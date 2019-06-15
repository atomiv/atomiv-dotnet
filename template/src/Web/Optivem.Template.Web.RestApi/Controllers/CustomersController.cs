using Microsoft.AspNetCore.Mvc;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Web.AspNetCore;
using System.Threading.Tasks;

namespace Optivem.Template.Web.Controllers
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

        // TODO: VC: Check swagger global responses, e.g. for validation?

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
            return CreatedAtRoute("find-customer", new { id = response.Id }, response); ;
        }

        // TODO: VC: Global at request validation, not found, so that we don't have if statements here

        [HttpPut("{id}", Name = "update-customer")]
        [ProducesResponseType(typeof(UpdateCustomerResponse), 201)]
        public async Task<ActionResult<UpdateCustomerResponse>> UpdateCustomerAsync(int id, UpdateCustomerRequest request)
        {
            var response = await Service.UpdateCustomerAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-customer")]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            await Service.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}