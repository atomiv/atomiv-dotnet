using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface IOrderService
	{
		public Task<IEnumerable<Order>> GetOrders();

		public Task<Order> GetOrder(int id);

		public Task<Order> PutOrder(Order order);

		public Task<Order> PostOrder(Order order);

		public Task<Order> DeleteOrder(int id);

	}
}
