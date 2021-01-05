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
		public Task<GetCustomersQueryResponse> GetCustomers();

		public Task<GetCustomerQueryResponse> GetCustomer(long id);

		public Task<UpdateCustomerCommandResponse> UpdateCustomer(UpdateCustomerCommand request);

		public Task<CreateCustomerCommandResponse> CreateCustomer(CreateCustomerCommand request);

		public Task<DeleteCustomerCommandResponse> DeleteCustomer(long id);
	}
}
