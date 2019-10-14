using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class AddCustomerHandler : AddAggregateRootHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public AddCustomerHandler(DatabaseContext context, IAddAggregateRootMapper<Customer, CustomerRecord> addAggregateRootMapper, IGetAggregateRootMapper<Customer, CustomerRecord> getAggregateRootMapper) : base(context, addAggregateRootMapper, getAggregateRootMapper)
        {
        }
    }
}
