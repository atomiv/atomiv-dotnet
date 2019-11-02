using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Handlers
{
    public class UpdateCustomerHandler : UpdateAggregateRootHandler<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>
    {
        public UpdateCustomerHandler(DatabaseContext context, IUpdateAggregateRootMapper<Customer, CustomerRecord> updateAggregateRootMapper, IGetAggregateRootMapper<Customer, CustomerRecord> getAggregateRootMapper) 
            : base(context, updateAggregateRootMapper, getAggregateRootMapper)
        {
        }
    }
}