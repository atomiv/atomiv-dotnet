using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers
{
    public class CustomerFactory : IAggregateRootFactory<Customer, CustomerRecord>
    {
        public Customer Create(CustomerRecord record)
        {
            var identity = new CustomerIdentity(record.Id);
            var firstName = record.FirstName;
            var lastName = record.LastName;

            return new Customer(identity, firstName, lastName);
        }
    }
}
