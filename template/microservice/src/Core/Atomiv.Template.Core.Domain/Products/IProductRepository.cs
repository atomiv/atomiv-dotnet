using Atomiv.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Products
{
    public interface IProductRepository : IProductReadonlyRepository, IRepository
    {
        Task AddAsync(Product product);

        Task<Product> FindAsync(ProductIdentity productId);

        Task UpdateAsync(Product product);

        Task SyncAsync(IEnumerable<Product> products);
    }
}