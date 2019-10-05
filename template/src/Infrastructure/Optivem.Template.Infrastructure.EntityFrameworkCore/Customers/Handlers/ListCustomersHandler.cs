using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class ListCustomersHandler : ListAggregateRootsHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public ListCustomersHandler(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
