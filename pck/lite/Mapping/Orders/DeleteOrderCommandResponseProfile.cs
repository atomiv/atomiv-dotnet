using Atomiv.Template.Lite.Dtos.Orders;
using Atomiv.Template.Lite.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Orders
{
	public class DeleteOrderResponseMap : Profile
	{
		public DeleteOrderResponseMap()
		{
			CreateMap<Order, DeleteOrderCommandResponse>();
		}
	}
}
