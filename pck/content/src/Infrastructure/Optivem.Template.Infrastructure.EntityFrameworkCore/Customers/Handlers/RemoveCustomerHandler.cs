using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class RemoveCustomerHandler : RemoveAggregateRootHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public RemoveCustomerHandler(DatabaseContext context, IRemoveAggregateRootMapper<CustomerIdentity, CustomerRecord> removeAggregateRootMapper) : base(context, removeAggregateRootMapper)
        {
        }
    }
}