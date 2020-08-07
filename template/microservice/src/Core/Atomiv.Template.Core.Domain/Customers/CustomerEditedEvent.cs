using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerEditedEvent : Event<CustomerIdentity>
    {
        public CustomerEditedEvent(CustomerReferenceNumber referenceNumber,
            string firstName,
            string lastName)
        {
            ReferenceNumber = referenceNumber;
            FirstName = firstName;
            LastName = lastName;
        }

        public CustomerReferenceNumber ReferenceNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
