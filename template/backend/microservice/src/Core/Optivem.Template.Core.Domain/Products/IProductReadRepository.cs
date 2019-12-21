using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductReadRepository : IRepository
    {
        Task<Product> FindAsync(ProductIdentity productId);

        Task<bool> ExistsAsync(ProductIdentity productId);

        Task<ListReadModel<ProductIdNameReadModel>> ListAsync();

        Task<PageReadModel<ProductHeaderReadModel>> GetPageAsync(PageQuery pageQuery);

        Task<long> CountAsync();
    }
}
