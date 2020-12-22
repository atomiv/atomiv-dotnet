using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Dtos.Orders
{
	public class UpdateOrderResponse
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public int CustomerId { get; set; }
		public List<OrderItem> OrderItems { get; set; }
	}
}
