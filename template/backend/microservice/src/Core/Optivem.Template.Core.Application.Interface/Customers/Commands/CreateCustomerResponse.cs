using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
