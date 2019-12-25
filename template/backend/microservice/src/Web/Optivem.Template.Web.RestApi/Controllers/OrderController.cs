using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Web.AspNetCore;
using Optivem.Template.Core.Application.Orders;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : BaseController<IOrderApplicationService>
    {
        public OrderController(IOrderApplicationService service) : base(service)
        {
        }

        [HttpPost("{id}/archive", Name = "archive-order")]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public async Task<ActionResult<OrderResponse>> ArchiveOrderAsync(Guid id)
        {
            var response = await Service.ArchiveOrderAsync(id);
            return Ok(response);
        }

        [HttpGet("browse", Name = "browse-orders")]
        [ProducesResponseType(typeof(BrowseOrdersResponse), 200)]
        public async Task<ActionResult<BrowseOrdersResponse>> BrowseOrdersAsync([FromQuery] int? page = null, [FromQuery] int? size = null)
        {
            var request = new BrowseOrdersRequest
            {
                Page = page.Value,
                Size = size.Value,
            };

            var response = await Service.BrowseOrdersAsync(request);
            return Ok(response);
        }

        [HttpPost("{id}/cancel", Name = "cancel-order")]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public async Task<ActionResult<OrderResponse>> CancelOrderAsync(Guid id)
        {
            var response = await Service.CancelOrderAsync(id);
            return Ok(response);
        }

        [HttpPost(Name = "create-order")]
        [ProducesResponseType(typeof(OrderResponse), 201)]
        public async Task<ActionResult<OrderResponse>> CreateOrderAsync(CreateOrderRequest request)
        {
            var response = await Service.CreateOrderAsync(request);
            return CreatedAtRoute("find-order", new { id = response.Id }, response);
        }

        [HttpGet("{id}", Name = "find-order")]
        [ProducesResponseType(typeof(FindOrderResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindOrderResponse>> FindOrderAsync(Guid id)
        {
            var response = await Service.FindOrderAsync(id);
            return Ok(response);
        }

        [HttpGet("list", Name = "list-orders")]
        [ProducesResponseType(typeof(ListOrdersResponse), 200)]
        public async Task<ActionResult<ListOrdersResponse>> ListOrdersAsync()
        {
            var request = new ListOrdersRequest();
            var response = await Service.ListOrdersAsync(request);
            return Ok(response);
        }

        [HttpPost("{id}/submit", Name = "submit-order")]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public async Task<ActionResult<OrderResponse>> SubmitOrderAsync(Guid id)
        {
            var response = await Service.SubmitOrderAsync(id);
            return Ok(response);
        }

        [HttpPut("{id}", Name = "update-order")]
        [ProducesResponseType(typeof(OrderResponse), 201)]
        public async Task<ActionResult<OrderResponse>> UpdateOrderAsync(Guid id, UpdateOrderRequest request)
        {
            var response = await Service.UpdateOrderAsync(request);
            return Ok(response);
        }
    }
}
