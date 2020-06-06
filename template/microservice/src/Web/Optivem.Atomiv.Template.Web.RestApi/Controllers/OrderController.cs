using Microsoft.AspNetCore.Mvc;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Commands.Orders;
using Optivem.Atomiv.Template.Core.Application.Queries.Orders;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public OrderController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        #region Commands

        [HttpPost("{id}/archive", Name = "archive-order")]
        [ProducesResponseType(typeof(ArchiveOrderCommandResponse), 200)]
        public async Task<ActionResult<ArchiveOrderCommandResponse>> ArchiveOrderAsync(Guid id)
        {
            var request = new ArchiveOrderCommand { Id = id };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpPost("{id}/cancel", Name = "cancel-order")]
        [ProducesResponseType(typeof(CancelOrderCommandResponse), 200)]
        public async Task<ActionResult<CancelOrderCommandResponse>> CancelOrderAsync(Guid id)
        {
            var request = new CancelOrderCommand { Id = id };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpPost(Name = "create-order")]
        [ProducesResponseType(typeof(CreateOrderCommandResponse), 201)]
        public async Task<ActionResult<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request)
        {
            var response = await _messageBus.SendAsync(request);
            return CreatedAtRoute("view-order", new { id = response.Id }, response);
        }

        [HttpPut("{id}", Name = "edit-order")]
        [ProducesResponseType(typeof(EditOrderCommandResponse), 201)]
        public async Task<ActionResult<EditOrderCommandResponse>> UpdateOrderAsync(Guid id, EditOrderCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest("Mismatching id in route and request");
            }

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpPost("{id}/submit", Name = "submit-order")]
        [ProducesResponseType(typeof(SubmitOrderCommandResponse), 200)]
        public async Task<ActionResult<SubmitOrderCommandResponse>> SubmitOrderAsync(Guid id)
        {
            var request = new SubmitOrderCommand { Id = id };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion

        #region Queries

        [HttpGet("browse", Name = "browse-orders")]
        [ProducesResponseType(typeof(BrowseOrdersQueryResponse), 200)]
        public async Task<ActionResult<BrowseOrdersQueryResponse>> BrowseOrdersAsync([FromQuery] int? page = 1, [FromQuery] int? size = 10)
        {
            var request = new BrowseOrdersQuery
            {
                Page = page.Value,
                Size = size.Value,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("filter", Name = "filter-orders")]
        [ProducesResponseType(typeof(FilterOrdersQueryResponse), 200)]
        public async Task<ActionResult<FilterOrdersQueryResponse>> FilterOrdersAsync()
        {
            var request = new FilterOrdersQuery();
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "view-order")]
        [ProducesResponseType(typeof(ViewOrderQueryResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ViewOrderQueryResponse>> ViewOrderAsync(Guid id)
        {
            var request = new ViewOrderQuery { Id = id };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion
    }
}
