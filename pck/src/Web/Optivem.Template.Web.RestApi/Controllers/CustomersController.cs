using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Web.AspNetCore;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Application.Customers.Services;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
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
            var request = new ListCustomersRequest();
            var response = await Service.ListCustomersAsync(request);
            return Ok(response);
        }

        // TODO: VC: Check swagger global responses, e.g. for validation?

        [HttpGet("{id}", Name = "find-customer")]
        [ProducesResponseType(typeof(FindCustomerResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindCustomerResponse>> FindCustomerAsync(int id)
        {
            var request = new FindCustomerRequest { Id = id };
            var response = await Service.FindCustomerAsync(request);
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
            // TODO: VC: API validation regarding id matching

            var response = await Service.UpdateCustomerAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-customer")]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            var request = new DeleteCustomerRequest { Id = id };
            var response = await Service.DeleteCustomerAsync(request);
            return NoContent();
        }
    }
}