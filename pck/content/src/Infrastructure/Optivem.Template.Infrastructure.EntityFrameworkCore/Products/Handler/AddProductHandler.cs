using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class AddProductHandler : AddAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public AddProductHandler(DatabaseContext context, IAddAggregateRootMapper<Product, ProductRecord> addAggregateRootMapper, IGetAggregateRootMapper<Product, ProductRecord> getAggregateRootMapper) : base(context, addAggregateRootMapper, getAggregateRootMapper)
        {
        }
    }
}