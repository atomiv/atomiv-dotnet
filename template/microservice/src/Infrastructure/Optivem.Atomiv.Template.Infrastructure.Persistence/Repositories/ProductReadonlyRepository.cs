using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.Repositories
{
    public class ProductReadonlyRepository : Repository, IProductReadonlyRepository
    {
        public ProductReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(Guid productId)
        {
            return Context.Products.AsNoTracking()
                .AnyAsync(e => e.Id == productId);
        }

        public Task<long> CountAsync()
        {
            return Context.Products.LongCountAsync();
        }

        public async Task<decimal?> GetPriceAsync(Guid productId)
        {
            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productId);

            if (productRecord == null)
            {
                return null;
            }

            return productRecord.ListPrice;
        }
    }
}
