using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class ExistsProductHandler : ExistsAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public ExistsProductHandler(DatabaseContext context) : base(context)
        {
        }
    }
}