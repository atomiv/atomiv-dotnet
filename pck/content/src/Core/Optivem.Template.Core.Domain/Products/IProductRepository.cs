using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductRepository : IProductReadRepository
    {
        Task<Product> AddAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task RemoveAsync(ProductIdentity productId);


    }
}