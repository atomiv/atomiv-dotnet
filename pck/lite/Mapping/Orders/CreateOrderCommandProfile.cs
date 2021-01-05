using Atomiv.Template.Lite.Dtos.Orders;
using Atomiv.Template.Lite.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Orders
{
	public class CreateOrderCommandProfile : Profile
	{
		public CreateOrderCommandProfile()
		{
			CreateMap<CreateOrderCommand, Order>();
		}
	}
}
