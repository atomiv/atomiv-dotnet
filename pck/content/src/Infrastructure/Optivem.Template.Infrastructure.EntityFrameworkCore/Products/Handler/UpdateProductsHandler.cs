using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class UpdateProductsHandler : UpdateAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public UpdateProductsHandler(DatabaseContext context, IAddAggregateRootMapper<Product, ProductRecord> addAggregateRootMapper) : base(context, addAggregateRootMapper)
        {
        }
    }
}