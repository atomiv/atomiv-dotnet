using Atomiv.Core.Application;
using Atomiv.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Events.Handlers.Customers
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        public Task HandleAsync(CustomerCreatedEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
