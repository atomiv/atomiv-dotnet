using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Mappers
{
    public class UpdateCustomerMapper : IUpdateAggregateRootMapper<Customer, CustomerRecord>
    {
        public CustomerRecord Map(Customer customer, CustomerRecord customerRecord)
        {
            var id = customer.Id.Id;
            var firstName = customer.FirstName;
            var lastName = customer.LastName;

            customerRecord.Id = id;
            customerRecord.FirstName = firstName;
            customerRecord.LastName = lastName;

            return customerRecord;
        }
    }
}
