using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRepository : Repository<Product, ProductIdentity>, IProductRepository
    {
        public ProductRepository(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<Product> AddAsync(Product aggregateRoot)
        {
            return HandleAddAggregateRootAsync(aggregateRoot);
        }

        public Task<bool> ExistsAsync(ProductIdentity identity)
        {
            return HandleExistsAggregateRootAsync(identity);
        }

        public Task<Product> FindAsync(ProductIdentity identity)
        {
            return HandleFindAggregateRootAsync(identity);
        }

        public Task<IEnumerable<Product>> ListAsync()
        {
            return HandleListAggregateRootsAsync();
        }

        public Task<PageAggregateRootsResponse<Product>> PageAsync(int page, int size)
        {
            return HandlePageAggregateRootsAsync(page, size);
        }

        public Task RemoveAsync(ProductIdentity identity)
        {
            return HandleRemoveAggregateRootAsync(identity);
        }

        public Task<Product> UpdateAsync(Product aggregateRoot)
        {
            return HandleUpdateAggregateRootAsync(aggregateRoot);
        }
    }
}