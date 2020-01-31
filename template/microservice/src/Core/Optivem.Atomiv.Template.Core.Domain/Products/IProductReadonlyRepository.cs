using Optivem.Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Domain.Products
{
    public interface IProductReadonlyRepository : IRepository
    {
        Task<bool> ExistsAsync(Guid productId);

        Task<long> CountAsync();

        Task<decimal?> GetPriceAsync(Guid productId);
    }
}
