using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class UpdateCustomerHandler : UpdateAggregateRootHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public UpdateCustomerHandler(DatabaseContext context, IAddAggregateRootMapper<Customer, CustomerRecord> addAggregateRootMapper) : base(context, addAggregateRootMapper)
        {
        }
    }
}
