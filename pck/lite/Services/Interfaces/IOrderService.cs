using Atomiv.Template.Lite.Dtos.Orders;
using Atomiv.Template.Lite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface IOrderService
	{
		public Task<GetOrdersQueryResponse> GetOrders();

		public Task<GetOrderQueryResponse> GetOrder(int id);

		public Task<UpdateOrderCommandResponse> UpdateOrder(UpdateOrderCommand request);

		public Task<CreateOrderCommandResponse> CreateOrder(CreateOrderCommand request);

		public Task<DeleteOrderCommandResponse> DeleteOrder(int id);

	}
}
