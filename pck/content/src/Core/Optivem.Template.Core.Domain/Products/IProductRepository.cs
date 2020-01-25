using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductRepository : IRepository
    {
        Task AddAsync(Product product);

        Task<Product> FindAsync(ProductIdentity productId);

        Task UpdateAsync(Product product);
    }
}