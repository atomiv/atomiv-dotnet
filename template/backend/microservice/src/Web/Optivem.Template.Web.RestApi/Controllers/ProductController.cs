using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Web.AspNetCore;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.Core.Application.Products.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : BaseController<IProductApplicationService>
    {
        public ProductController(IProductApplicationService service)
            : base(service)
        {
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

            var response = await Service.BrowseProductsAsync(request);
            return Ok(response);
        }

        [HttpGet("list", Name = "list-products")]
        [ProducesResponseType(typeof(ListProductsQueryResponse), 200)]
        public async Task<ActionResult<ListProductsQueryResponse>> ListProductsAsync()
        {
            var request = new ListProductQuery { };
            var response = await Service.ListProductsAsync(request);
            return Ok(response);
        }
    }
}