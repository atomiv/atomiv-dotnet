using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services
{
	public class OrderService: IOrderService
	{
        private readonly ECommerceContext _context;

		public OrderService(ECommerceContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Order>> GetOrders()
		{
			return await _context.Orders.Include(t => t.OrderItems).ToListAsync();
		}


		public async Task<Order> GetOrder(int id)
		{
		    var order = await _context.Orders.Include(t => t.OrderItems).FirstOrDefaultAsync(t => t.Id == id);

		    if (order == null)
		    {
		        return null;
		    }

		    return order;
		}

		public async Task<Order> UpdateOrder(Order order)
		{

			_context.Entry(order).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				var id = order.Id;

				if (!OrderExists(id))
				{
					return null;
				}
				else
				{
					throw;
				}
			}

			return null;
		}


		public async Task<Order> CreateOrder(Order order)
		{
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();

			return order;
		}


		public async Task<Order> DeleteOrder(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order == null)
			{
				return null;
			}

			_context.Orders.Remove(order);
			await _context.SaveChangesAsync();

			return order;
		}


		private bool OrderExists(int id)
		{
			return _context.Orders.Any(e => e.Id == id);
		}

	}
}
