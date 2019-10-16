using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class ListProductsHandler : ListAggregateRootsHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public ListProductsHandler(DatabaseContext context, IGetAggregateRootMapper<Product, ProductRecord> getAggregateRootMapper) : base(context, getAggregateRootMapper)
        {
        }
    }
}