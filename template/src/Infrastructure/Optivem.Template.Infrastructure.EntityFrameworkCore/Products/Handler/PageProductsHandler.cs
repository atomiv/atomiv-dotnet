using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handler
{
    public class PageProductsHandler : PageAggregateRootsHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public PageProductsHandler(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
