using Microsoft.AspNetCore.Mvc;
using Optivem.Template.Core.Application.Products;
using Optivem.Web.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : BaseController<IProductService>
    {
        public ProductsController(IProductService service)
            : base(service)
        {
        }

        /*
        [HttpGet(Name = "browse-products")]
        [ProducesResponseType(typeof(BrowseProductsResponse), 200)]
        public async Task<ActionResult<BrowseProductsResponse>> BrowseProductsAsync(int? Page = null, int? Size = null)
        {
            // TODO: VC: Parameter validation
            var request = new BrowseProductsRequest
            {
                Page = Page.Value,
                Size = Size.Value,
            };

            var response = await Service.BrowseProductsAsync(request);
            return Ok(response);
        }
        */

        [HttpGet(Name = "list-products")]
        [ProducesResponseType(typeof(ListProductsResponse), 200)]
        public async Task<ActionResult<ListProductsResponse>> ListProductsAsync()
        {
            var response = await Service.ListProductsAsync();
            return Ok(response);
        }

        // TODO: VC: Include

        /*


        // TODO: VC: Check swagger global responses, e.g. for validation?

        [HttpGet("{id}", Name = "find-customer")]
        [ProducesResponseType(typeof(FindCustomerResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindCustomerResponse>> FindCustomerAsync(int id)
        {
            var response = await Service.FindCustomerAsync(id);
            return Ok(response);
        }

        [HttpPost(Name = "create-customer")]
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
            var response = await Service.UpdateCustomerAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-customer")]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            await Service.DeleteCustomerAsync(id);
            return NoContent();
        }

    */
    }
}
