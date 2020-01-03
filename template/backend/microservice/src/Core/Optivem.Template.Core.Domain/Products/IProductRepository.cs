using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductRepository : IRepository
    {
        void Add(Product product);

        Task UpdateAsync(Product product);

        Task<Product> FindAsync(ProductIdentity productId);
    }
}