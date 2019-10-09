using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class FindCustomerHandler : FindAggregateRootHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public FindCustomerHandler(DatabaseContext context, IMapper mapper, IAggregateRootFactory<Customer, CustomerRecord> aggregateRootFactory) 
            : base(context, mapper, aggregateRootFactory)
        {
        }
    }
}
