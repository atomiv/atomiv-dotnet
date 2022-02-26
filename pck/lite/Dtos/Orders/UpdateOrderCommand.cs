using Atomiv.Template.Lite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Dtos.Orders
{
	public class UpdateOrderCommand
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public int CustomerId { get; set; }
		public List<OrderItem> OrderItems { get; set; }
	}
}
