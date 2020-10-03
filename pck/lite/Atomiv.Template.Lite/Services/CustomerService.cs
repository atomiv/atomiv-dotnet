using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Repositories;
using Atomiv.Template.Lite.Repositories.Interfaces;
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
		private readonly ICustomerRepository _customerRepository;
		// constructor
		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
		public Task<Customer> CreateCustomer(Customer customer)
		{
			return _customerRepository.CreateCustomer(customer);
		}

		public Task<Customer> DeleteCustomer(long id)
		{
			return _customerRepository.DeleteCustomer(id);
		}

		public Task<Customer> GetCustomer(long id)
		{
			return _customerRepository.GetCustomer(id);
		}

		public Task<IEnumerable<Customer>> GetCustomers()
		{
			return _customerRepository.GetCustomers();
		}

		public Task<Customer> UpdateCustomer(Customer customer)
		{
			return _customerRepository.UpdateCustomer(customer);
		}
	}
}
