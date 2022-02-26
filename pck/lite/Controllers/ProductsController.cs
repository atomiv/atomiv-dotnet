using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Entities;
using Atomiv.Template.Lite.Services.Interfaces;
using Atomiv.Template.Lite.Dtos.Products;

namespace Atomiv.Template.Lite.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<GetProductQueryResponse>> GetProducts()
        {
            var products = await _service.GetProducts();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductQueryResponse>> GetProduct(int id)
        {
            var product = await _service.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _service.UpdateProduct(request);

            if (response == null)
			{
                return NotFound();
			}

            return NoContent();

        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductCommand request)
        {
            var response = await _service.CreateProduct(request);
            
            return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductCommandResponse>> DeleteProduct(int id)
        {
            var product = await _service.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
