using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class AddProductHandler : AddAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public AddProductHandler(DatabaseContext context, IMapper mapper, IAggregateRootFactory<Product, ProductRecord> aggregateRootFactory) 
            : base(context, mapper, aggregateRootFactory)
        {
        }
    }
}
