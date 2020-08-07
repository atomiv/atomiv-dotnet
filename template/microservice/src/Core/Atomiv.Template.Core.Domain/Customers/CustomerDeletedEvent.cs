using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerDeletedEvent : Event<CustomerIdentity>
    {
        public CustomerDeletedEvent(CustomerIdentity id) 
            : base(id)
        {
        }
    }
}
