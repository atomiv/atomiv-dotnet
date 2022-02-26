using Atomiv.Template.Lite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Repositories.Interfaces
{
	public interface IProductRepository
	{
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> GetProduct(int id);

        public Task<Product> UpdateProduct(Product product);

        public Task<Product> CreateProduct(Product product);

        public Task<Product> DeleteProduct(int id);

    }
}
