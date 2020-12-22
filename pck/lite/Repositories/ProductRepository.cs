using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Repositories
{
	public class ProductRepository : IProductRepository
	{
                
        private readonly ECommerceContext _context;

        public ProductRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;

            try
			{
                await _context.SaveChangesAsync();
			}
            catch (DbUpdateConcurrencyException)
			{
                var id = product.Id;

                if (!ProductExists(id))
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

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }


        private bool ProductExists(int id)
		{
            return _context.Products.Any(e => e.Id == id);
		}


    }
}
