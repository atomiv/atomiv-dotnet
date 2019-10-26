using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class UpdateProductsHandler : UpdateAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public UpdateProductsHandler(DatabaseContext context, IUpdateAggregateRootMapper<Product, ProductRecord> updateAggregateRootMapper, IGetAggregateRootMapper<Product, ProductRecord> getAggregateRootMapper) 
            : base(context, updateAggregateRootMapper, getAggregateRootMapper)
        {
        }
    }
}