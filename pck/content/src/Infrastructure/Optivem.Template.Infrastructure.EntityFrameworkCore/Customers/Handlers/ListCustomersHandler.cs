using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class ListCustomersHandler : ListAggregateRootsHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public ListCustomersHandler(DatabaseContext context, IGetAggregateRootMapper<Customer, CustomerRecord> getAggregateRootMapper) : base(context, getAggregateRootMapper)
        {
        }
    }
}