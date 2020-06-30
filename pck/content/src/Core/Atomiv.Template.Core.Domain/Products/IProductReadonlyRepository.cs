using Atomiv.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Products
{
    public interface IProductReadonlyRepository : IRepository
    {
        Task<IReadonlyProduct> FindReadonlyAsync(ProductIdentity productId);

        Task<IEnumerable<IReadonlyProduct>> FindReadonlyAsync(IEnumerable<ProductIdentity> productIds);

        Task<bool> ExistsAsync(ProductIdentity productId);

        Task<long> CountAsync();
    }
}
