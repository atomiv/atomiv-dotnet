using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly IIdentityGenerator<CustomerIdentity> _customerIdentityGenerator;

        public CustomerFactory(IIdentityGenerator<CustomerIdentity> customerIdentityGenerator)
        {
            _customerIdentityGenerator = customerIdentityGenerator;
        }

        public Customer Create(string firstName, string lastName)
        {
            var id = _customerIdentityGenerator.Next();

            return new Customer(id, firstName, lastName);
        }
    }
}
