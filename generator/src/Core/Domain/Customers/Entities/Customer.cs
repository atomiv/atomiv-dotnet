using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Domain.Customers.Entities
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