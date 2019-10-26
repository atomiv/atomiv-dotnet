using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Mappers
{
    public class RemoveCustomerMapper : IRemoveAggregateRootMapper<CustomerIdentity, CustomerRecord>
    {
        public CustomerRecord Map(CustomerIdentity identity)
        {
            var id = identity.Id;

            return new CustomerRecord
            {
                Id = id,
            };
        }
    }
}