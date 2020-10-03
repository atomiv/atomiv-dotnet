// TODO VC wshould i delete the waethe files and in .son as well - edit taht

// "launchUrl": "weatherforecast",
// api/customers

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Services.Interfaces;
using Atomiv.Template.Lite.Dtos.Customers;

// TODO ECommerceAPI.Controllers
namespace Atomiv.Template.Lite.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // private readonly ECommerceContext _context;
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        // GET: api/Customers
        /// <summary>
        /// The GET method returns fake customers
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<GetCustomersResponse>> GetCustomers()
        {
            // Customers.ToListAsync();
            var customers = await _service.GetCustomers();
            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerResponse>> GetCustomer(long id)
        {
            var customer = await _service.GetCustomer(id);

            // .Customers that's why in ECommerceContexr it's plural
            // var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            //return customer;
            return Ok(customer);
        }

        // PUT = update
        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see //go.microsoft.com/fwlink/?linkid=2123754.
        // public void Put(int id, [FromBody] string value)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, UpdateCustomerRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _service.UpdateCustomer(request);
            //_context.Entry(customer).State = EntityState.Modified;

            if (response == null)
			{
                return NotFound();
			}

            return NoContent();

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CustomerExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }


        // POST = create new
        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        // public void Post([FromBody] string value)
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomerRequest request)
        {
            var response = await _service.CreateCustomer(request);
            //_context.Customers.Add(customer);
            //await _context.SaveChangesAsync();

            // return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = response.Id }, response);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCustomerResponse>> DeleteCustomer(long id)
        {
            var customer = await _service.DeleteCustomer(id);
            //var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            //_context.Customers.Remove(customer);
            //await _context.SaveChangesAsync();

            //return customer;
            return Ok(customer);
        }

        //private bool CustomerExists(long id)
        //{
        //    return _context.Customers.Any(e => e.Id == id);
        //}
    }
}
