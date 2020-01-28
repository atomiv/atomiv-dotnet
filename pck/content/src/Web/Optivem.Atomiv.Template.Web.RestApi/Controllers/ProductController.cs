using Microsoft.AspNetCore.Mvc;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestApi.Controllers
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
            return CreatedAtRoute("find-product", new { id = response.Id }, response);
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

        [HttpPut(Name = "update-product")]
        [ProducesResponseType(typeof(UpdateProductCommandResponse), 200)]
        public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProductAsync(UpdateProductCommand request)
        {
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion

        #region Queries

        [HttpGet(Name = "browse-products")]
        [ProducesResponseType(typeof(BrowseProductsQueryResponse), 200)]
        public async Task<ActionResult<BrowseProductsQueryResponse>> BrowseProductsAsync([FromQuery] int? page = null, [FromQuery] int? size = null)
        {
            var request = new BrowseProductsQuery
            {
                Page = page.Value,
                Size = size.Value,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "find-product")]
        [ProducesResponseType(typeof(FindProductQueryResponse), 200)]
        public async Task<ActionResult<FindProductQueryResponse>> FindProductAsync(Guid id)
        {
            var request = new FindProductQuery
            {
                Id = id,
            };

            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }


        [HttpGet("list", Name = "list-products")]
        [ProducesResponseType(typeof(ListProductsQueryResponse), 200)]
        public async Task<ActionResult<ListProductsQueryResponse>> ListProductsAsync()
        {
            var request = new ListProductsQuery { };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }

        #endregion




    }
}