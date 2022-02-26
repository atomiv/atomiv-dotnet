using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Dtos.Products
{
	public class DeleteProductCommandResponse
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool IsListed { get; set; }
	}
}
