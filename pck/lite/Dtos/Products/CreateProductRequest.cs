using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Dtos.Products
{
	public class CreateProductRequest
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool IsListed { get; set; }
	}
}
