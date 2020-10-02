using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface IProductService
	{
		public Task<IEnumerable<Product>> GetProducts();

		public Task<Product> GetProduct(int id);

		public Task<Product> PutProduct(Product product);

		public Task<Product> PostProduct(Product product);

		public Task<Product> DeleteProduct(int id);

	}
}
