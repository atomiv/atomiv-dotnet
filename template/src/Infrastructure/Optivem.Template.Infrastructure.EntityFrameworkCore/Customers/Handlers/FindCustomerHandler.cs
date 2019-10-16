using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class FindCustomerHandler : FindAggregateRootHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public FindCustomerHandler(DatabaseContext context, IGetAggregateRootMapper<Customer, CustomerRecord> getAggregateRootMapper) : base(context, getAggregateRootMapper)
        {
        }
    }
}