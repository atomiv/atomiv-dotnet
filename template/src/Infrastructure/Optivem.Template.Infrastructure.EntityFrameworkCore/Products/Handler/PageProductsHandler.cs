using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class PageProductsHandler : PageAggregateRootsHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public PageProductsHandler(DatabaseContext context, IGetAggregateRootMapper<Product, ProductRecord> getAggregateRootMapper) : base(context, getAggregateRootMapper)
        {
        }
    }
}