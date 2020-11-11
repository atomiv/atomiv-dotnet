using Microsoft.AspNetCore.Mvc;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Queries.Customers;
using System.Threading.Tasks;
using System;

namespace Atomiv.Template.Web.RestApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CustomerController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        #region Commands

        [HttpPost(Name = "create-customer")]
        [ProducesResponseType(typeof(CreateCustomerCommandResponse), 201)]
        public async Task<ActionResult<CreateCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request)
        {
            var response = await _commandBus.SendAsync(request);
            return CreatedAtRoute("view-customer", new { id = response.Id }, response);
        }

        [HttpPut("{id}", Name = "edit-customer")]
        [ProducesResponseType(typeof(EditCustomerCommandResponse), 201)]
        public async Task<ActionResult<EditCustomerCommandResponse>> EditCustomerAsync(Guid id, EditCustomerCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest("Mismatching id in route and request");
            }

            var response = await _commandBus.SendAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-customer")]
        public async Task<ActionResult> DeleteCustomerAsync(Guid id)
        {
            var request = new DeleteCustomerCommand
            {
                Id = id,
            };

            await _commandBus.SendAsync(request);
            return NoContent();
        }

        #endregion

        #region Queries

        [HttpGet(Name = "browse-customers")]
        [ProducesResponseType(typeof(BrowseCustomersQueryResponse), 200)]
        public async Task<ActionResult<BrowseCustomersQueryResponse>> BrowseCustomersAsync([FromQuery] int? page = 1, [FromQuery] int? size = 10)
        {
            var request = new BrowseCustomersQuery
            {
                Page = page.Value,
                Size = size.Value,
            };

            var response = await _queryBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("filter", Name = "filter-customers")]
        [ProducesResponseType(typeof(FilterCustomersQueryResponse), 200)]
        public async Task<ActionResult<FilterCustomersQueryResponse>> FilterCustomersAsync(int limit, string nameSearch)
        {
            var request = new FilterCustomersQuery
            {
                Limit = limit,
                NameSearch = nameSearch,
            };

            var response = await _queryBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "view-customer")]
        [ProducesResponseType(typeof(ViewCustomerQueryResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ViewCustomerQueryResponse>> ViewCustomerAsync(Guid id)
        {
            var request = new ViewCustomerQuery
            {
                Id = id,
            };

            var response = await _queryBus.SendAsync(request);
            return Ok(response);
        }

        #endregion
    }
}