using Atomiv.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Products
{
    public interface IProductReadonlyRepository : IRepository
    {
        Task<bool> ExistsAsync(Guid productId);

        Task<long> CountAsync();

        Task<decimal?> GetPriceAsync(Guid productId);
    }
}
