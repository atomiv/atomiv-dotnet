using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface ICustomerService
	{
		public Task<IEnumerable<Customer>> GetCustomers();

		public Task<Customer> GetCustomer(long id);

		public Task<Customer> PutCustomer(Customer customer);

		public Task<Customer> PostCustomer(Customer customer);

		public Task<Customer> DeleteCustomer(long id);
	}
}
