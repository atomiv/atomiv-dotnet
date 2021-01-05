using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Customers
{
	public class GetCustomerQueryResponseProfile : Profile
	{
		public GetCustomerQueryResponseProfile()
		{
			CreateMap<Customer, GetCustomerQueryResponse>();
		}
	}
}
