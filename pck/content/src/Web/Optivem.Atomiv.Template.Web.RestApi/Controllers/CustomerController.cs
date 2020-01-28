using Microsoft.AspNetCore.Mvc;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public CustomerController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        #region Commands

        [HttpPost(Name = "create-customer")]
        [ProducesResponseType(typeof(CreateCustomerCommandResponse), 201)]
        public async Task<ActionResult<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request)
        {
            var response = await _messageBus.SendAsync(request);
            return CreatedAtRoute("find-customer", new { id = response.Id }, response);
        }

        [HttpPut("{id}", Name = "update-customer")]
        [ProducesResponseType(typeof(UpdateCustomerCommandResponse), 201)]
        public async Task<ActionResult<UpdateCustomerCommandResponse>> UpdateCustomerAsync(Guid id, UpdateCustomerCommand request)
        {
            if (id != request.Id)
            {
                // TODO: VC: Move to translations
                return BadRequest("Mismatching id in route and request");
            }

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-customer")]
        public async Task<ActionResult> DeleteCustomerAsync(Guid id)
        {
            var request = new DeleteCustomerCommand
            {
                Id = id,
            };

            await _messageBus.SendAsync(request);
            return NoContent();
        }

        #endregion

        #region Queries

        [HttpGet(Name = "browse-customers")]
        [ProducesResponseType(typeof(BrowseCustomersQueryResponse), 200)]
        public async Task<ActionResult<BrowseCustomersQueryResponse>> BrowseCustomersAsync(int page, int size)
        {
            var request = new BrowseCustomersQuery
            {
                Page = page,
                Size = size,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "find-customer")]
        [ProducesResponseType(typeof(FindCustomerQueryResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindCustomerQueryResponse>> FindCustomerAsync(Guid id)
        {
            var request = new FindCustomerQuery
            {
                Id = id,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("list", Name = "list-customers")]
        [ProducesResponseType(typeof(ListCustomersQueryResponse), 200)]
        public async Task<ActionResult<ListCustomersQueryResponse>> ListCustomersAsync(int limit, string nameSearch)
        {
            var request = new ListCustomersQuery
            {
                Limit = limit,
                NameSearch = nameSearch,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion
    }
}