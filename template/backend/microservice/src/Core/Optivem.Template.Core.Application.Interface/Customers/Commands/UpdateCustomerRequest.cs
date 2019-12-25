using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class UpdateCustomerRequest : IRequest<CustomerResponse>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}