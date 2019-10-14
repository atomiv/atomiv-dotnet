using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Mappers
{
    public class RemoveCustomerMapper : IRemoveAggregateRootMapper<CustomerIdentity, CustomerRecord>
    {
        public CustomerRecord Create(CustomerIdentity identity)
        {
            var id = identity.Id;

            return new CustomerRecord
            {
                Id = id,
            };
        }
    }
}
