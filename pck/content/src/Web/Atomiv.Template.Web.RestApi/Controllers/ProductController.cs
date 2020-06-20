using Microsoft.AspNetCore.Mvc;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Application.Queries.Products;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Web.RestApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public ProductController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        #region Commands

        [HttpPost(Name = "create-product")]
        [ProducesResponseType(typeof(CreateProductCommandResponse), 201)]
        public async Task<ActionResult<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request)
        {
            var response = await _messageBus.SendAsync(request);
            return CreatedAtRoute("view-product", new { id = response.Id }, response);
        }


        [HttpPut("{id}", Name = "edit-product")]
        [ProducesResponseType(typeof(EditProductCommandResponse), 200)]
        public async Task<ActionResult<EditProductCommandResponse>> EditProductAsync(Guid id, EditProductCommand request)
        {
            if(id != request.Id)
            {
                return BadRequest("Mismatching id in route and request");
            }

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpPost("{id}/relist", Name = "relist-product")]
        [ProducesResponseType(typeof(RelistProductCommandResponse), 200)]
        public async Task<ActionResult<RelistProductCommandResponse>> RelistProductAsync(Guid id)
        {
            var request = new RelistProductCommand
            {
                Id = id,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpPost("{id}/unlist", Name = "unlist-product")]
        [ProducesResponseType(typeof(UnlistProductCommandResponse), 200)]
        public async Task<ActionResult<UnlistProductCommandResponse>> UnlistProductAsync(Guid id)
        {
            var request = new UnlistProductCommand
            {
                Id = id,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion

        #region Queries

        [HttpGet(Name = "browse-products")]
        [ProducesResponseType(typeof(BrowseProductsQueryResponse), 200)]
        public async Task<ActionResult<BrowseProductsQueryResponse>> BrowseProductsAsync([FromQuery] int? page = 1, [FromQuery] int? size = 10)
        {
            var request = new BrowseProductsQuery
            {
                Page = page.Value,
                Size = size.Value,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("filter", Name = "filter-products")]
        [ProducesResponseType(typeof(FilterProductsQueryResponse), 200)]
        public async Task<ActionResult<FilterProductsQueryResponse>> FilterProductsAsync()
        {
            var request = new FilterProductsQuery { };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "view-product")]
        [ProducesResponseType(typeof(ViewProductQueryResponse), 200)]
        public async Task<ActionResult<ViewProductQueryResponse>> ViewProductAsync(Guid id)
        {
            var request = new ViewProductQuery
            {
                Id = id,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion
    }
}