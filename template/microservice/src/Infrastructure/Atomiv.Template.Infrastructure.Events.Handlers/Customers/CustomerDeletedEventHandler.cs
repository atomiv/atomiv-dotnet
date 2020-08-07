using Atomiv.Core.Application;
using Atomiv.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Events.Handlers.Customers
{
    public class CustomerDeletedEventHandler : IEventHandler<CustomerDeletedEvent>
    {
        public Task HandleAsync(CustomerDeletedEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
