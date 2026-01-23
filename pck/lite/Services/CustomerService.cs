using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Entities;
using Atomiv.Template.Lite.Repositories;
using Atomiv.Template.Lite.Repositories.Interfaces;
using Atomiv.Template.Lite.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Atomiv.Template.Lite.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;

		// constructor
		public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}
		//maps from CustomerRequest into customer model
		public async Task<CreateCustomerCommandResponse> CreateCustomer(CreateCustomerCommand request)
		{
			var customer = _mapper.Map<CreateCustomerCommand, Customer>(request);
			customer = await _customerRepository.CreateCustomer(customer);
			return _mapper.Map<Customer, CreateCustomerCommandResponse>(customer);
		}

		public async Task<DeleteCustomerCommandResponse> DeleteCustomer(long id)
		{
			var customer = await _customerRepository.DeleteCustomer(id);
			return _mapper.Map<Customer, DeleteCustomerCommandResponse>(customer);
		}

		public async Task<GetCustomerQueryResponse> GetCustomer(long id)
		{
			var customer = await _customerRepository.GetCustomer(id);
			return _mapper.Map<Customer, GetCustomerQueryResponse>(customer);
		}

		public async Task<GetCustomersQueryResponse> GetCustomers()
		{
			var customers = await _customerRepository.GetCustomers();
			return _mapper.Map<IEnumerable<Customer>, GetCustomersQueryResponse>(customers);
		}

		public async Task<UpdateCustomerCommandResponse> UpdateCustomer(UpdateCustomerCommand request)
		{
			var customer = _mapper.Map<UpdateCustomerCommand, Customer>(request);
			customer = await _customerRepository.UpdateCustomer(customer);
			return _mapper.Map<Customer, UpdateCustomerCommandResponse>(customer);
		}
	}
}
