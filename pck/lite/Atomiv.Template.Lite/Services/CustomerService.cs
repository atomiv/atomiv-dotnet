using Atomiv.Template.Lite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services
{
	public class CustomerService
	{
        private readonly ECommerceContext _context;

        public CustomerService(ECommerceContext context)
        {
            _context = context;
        }

		public async Task<IEnumerable<Customer>> GetCustomers()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetCustomer(long id)
		{
			var customer = await _context.Customers.FindAsync(id);

			if (customer == null)
			{
				return null;
			}

			return customer;
		}


		public async Task<Customer> PutCustomer(Customer customer)
		{

			_context.Entry(customer).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				var id = customer.Id;

				if (!CustomerExists(id))
				{
					return null;
				}
				else
				{
					throw;
				}
			}

			return null;
		}



		public async Task<Customer> PostCustomer(Customer customer)
		{
			_context.Customers.Add(customer);
			await _context.SaveChangesAsync();

			return customer;
		}


		public async Task<Customer> DeleteCustomer(long id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer == null)
			{
				return null;
			}

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();

			return customer;
		}




		//// POST = create new
		//// POST: api/Customers
		//// To protect from overposting attacks, enable the specific properties you want to bind to, for
		//// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		//[HttpPost]
		//// public void Post([FromBody] string value)
		//public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
		//{
		//    _context.Customers.Add(customer);
		//    await _context.SaveChangesAsync();

		//    // return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
		//    return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
		//}

		//// DELETE: api/Customers/5
		//[HttpDelete("{id}")]
		//public async Task<ActionResult<Customer>> DeleteCustomer(long id)
		//{
		//    var customer = await _context.Customers.FindAsync(id);
		//    if (customer == null)
		//    {
		//        return NotFound();
		//    }

		//    _context.Customers.Remove(customer);
		//    await _context.SaveChangesAsync();

		//    return customer;
		//}

		private bool CustomerExists(long id)
		{
			return _context.Customers.Any(e => e.Id == id);
		}






	}
}
