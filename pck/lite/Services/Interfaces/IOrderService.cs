using Atomiv.Template.Lite.Dtos.Orders;
using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface IOrderService
	{
		public Task<GetOrdersResponse> GetOrders();

		public Task<GetOrderResponse> GetOrder(int id);

		public Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request);

		public Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request);

		public Task<DeleteOrderResponse> DeleteOrder(int id);

	}
}
