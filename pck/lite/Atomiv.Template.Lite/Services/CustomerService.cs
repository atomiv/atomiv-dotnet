using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Repositories;
using Atomiv.Template.Lite.Repositories.Interfaces;
using Atomiv.Template.Lite.Services.Interfaces;
using AutoMapper;
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
		public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
		{
			var customer = _mapper.Map<CreateCustomerRequest, Customer>(request);
			customer = await _customerRepository.CreateCustomer(customer);
			return _mapper.Map<Customer, CreateCustomerResponse>(customer);
		}

		public async Task<DeleteCustomerResponse> DeleteCustomer(long id)
		{
			var customer = await _customerRepository.DeleteCustomer(id);
			return _mapper.Map<Customer, DeleteCustomerResponse>(customer);
		}

		public async Task<GetCustomerResponse> GetCustomer(long id)
		{
			var customer = await _customerRepository.GetCustomer(id);
			return _mapper.Map<Customer, GetCustomerResponse>(customer);
		}

		public async Task<GetCustomersResponse> GetCustomers()
		{
			var customers = await _customerRepository.GetCustomers();
			return _mapper.Map<IEnumerable<Customer>, GetCustomersResponse>(customers);
		}

		public async Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request)
		{
			var customer = _mapper.Map<UpdateCustomerRequest, Customer>(request);
			customer = await _customerRepository.UpdateCustomer(customer);
			return _mapper.Map<Customer, UpdateCustomerResponse>(customer);
		}
	}
}
