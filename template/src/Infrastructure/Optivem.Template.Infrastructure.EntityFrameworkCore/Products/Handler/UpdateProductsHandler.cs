using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Handlers
{
    public class UpdateProductsHandler : UpdateAggregateRootHandler<DatabaseContext, Product, ProductIdentity, ProductRecord, int>
    {
        public UpdateProductsHandler(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
