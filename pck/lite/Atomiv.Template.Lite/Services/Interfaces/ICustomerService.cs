using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface ICustomerService
	{
		public Task<GetCustomersResponse> GetCustomers();

		public Task<GetCustomerResponse> GetCustomer(long id);

		public Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request);

		public Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request);

		public Task<DeleteCustomerResponse> DeleteCustomer(long id);
	}
}
