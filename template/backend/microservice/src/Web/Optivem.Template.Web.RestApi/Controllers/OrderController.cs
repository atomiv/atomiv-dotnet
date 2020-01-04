using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
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

        [HttpPost("{id}/archive", Name = "archive-order")]
        [ProducesResponseType(typeof(ArchiveOrderCommandResponse), 200)]
        public async Task<ActionResult<ArchiveOrderCommandResponse>> ArchiveOrderAsync(Guid id)
        {
            var request = new ArchiveOrderCommand { Id = id };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("browse", Name = "browse-orders")]
        [ProducesResponseType(typeof(BrowseOrdersQueryResponse), 200)]
        public async Task<ActionResult<BrowseOrdersQueryResponse>> BrowseOrdersAsync([FromQuery] int? page = null, [FromQuery] int? size = null)
        {
            var request = new BrowseOrdersQuery
            {
                Page = page.Value,
                Size = size.Value,
            };

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
            return CreatedAtRoute("find-order", new { id = response.Id }, response);
        }

        [HttpGet("{id}", Name = "find-order")]
        [ProducesResponseType(typeof(FindOrderQueryResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindOrderQueryResponse>> FindOrderAsync(Guid id)
        {
            var request = new FindOrderQuery { Id = id };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("list", Name = "list-orders")]
        [ProducesResponseType(typeof(ListOrdersQueryResponse), 200)]
        public async Task<ActionResult<ListOrdersQueryResponse>> ListOrdersAsync()
        {
            var request = new ListOrdersQuery();
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

        [HttpPut("{id}", Name = "update-order")]
        [ProducesResponseType(typeof(UpdateOrderCommandResponse), 201)]
        public async Task<ActionResult<UpdateOrderCommandResponse>> UpdateOrderAsync(Guid id, UpdateOrderCommand request)
        {
            if (id != request.Id)
            {
                // TODO: VC: Move to translations
                return BadRequest("Mismatching id in route and request");
            }

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }
    }
}
