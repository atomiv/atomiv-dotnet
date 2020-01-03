using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
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

        [HttpGet("list", Name = "list-products")]
        [ProducesResponseType(typeof(ListProductsQueryResponse), 200)]
        public async Task<ActionResult<ListProductsQueryResponse>> ListProductsAsync()
        {
            var request = new ListProductsQuery { };
            var response = await _messageBus.SendAsync(request);
            return Ok(response);
        }
    }
}