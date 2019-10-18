using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class RemoveProductsHandler : RemoveAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public RemoveProductsHandler(DatabaseContext context, IRemoveAggregateRootMapper<ProductIdentity, ProductRecord> removeAggregateRootMapper) : base(context, removeAggregateRootMapper)
        {
        }
    }
}