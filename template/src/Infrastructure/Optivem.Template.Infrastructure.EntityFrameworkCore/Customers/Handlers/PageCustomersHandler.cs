using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class PageCustomersHandler : PageAggregateRootsHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public PageCustomersHandler(DatabaseContext context, IGetAggregateRootMapper<Customer, CustomerRecord> getAggregateRootMapper) : base(context, getAggregateRootMapper)
        {
        }
    }
}
