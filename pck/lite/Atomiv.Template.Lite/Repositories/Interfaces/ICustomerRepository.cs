using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Repositories.Interfaces
{
	public interface ICustomerRepository
	{
		public Task<IEnumerable<Customer>> GetCustomers();

		public Task<Customer> GetCustomer(long id);

		public Task<Customer> UpdateCustomer(Customer customer);

		public Task<Customer> CreateCustomer(Customer customer);

		public Task<Customer> DeleteCustomer(long id);

	}
}
