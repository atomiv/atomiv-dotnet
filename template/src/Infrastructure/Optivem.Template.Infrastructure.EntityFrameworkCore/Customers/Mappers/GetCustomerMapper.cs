using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Mappers
{
    public class GetCustomerMapper : IGetAggregateRootMapper<Customer, CustomerRecord>
    {
        public Customer Map(CustomerRecord record)
        {
            var identity = new CustomerIdentity(record.Id);
            var firstName = record.FirstName;
            var lastName = record.LastName;

            return new Customer(identity, firstName, lastName);
        }

        public List<Expression<Func<CustomerRecord, object>>> GetIncludes()
        {
            return null;
        }
    }
}