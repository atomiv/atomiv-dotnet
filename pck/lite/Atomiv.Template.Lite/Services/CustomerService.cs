using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services
{
	public class CustomerService : ICustomerService
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


		public async Task<Customer> UpdateCustomer(Customer customer)
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



		public async Task<Customer> CreateCustomer(Customer customer)
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


		private bool CustomerExists(long id)
		{
			return _context.Customers.Any(e => e.Id == id);
		}


	}
}
