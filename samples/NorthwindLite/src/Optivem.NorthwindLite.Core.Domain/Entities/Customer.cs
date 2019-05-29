using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Domain.Identities;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class Customer : AggregateRoot<CustomerIdentity>
    {
        public Customer(CustomerIdentity id, string firstName, string lastName) 
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}