using Atomiv.Core.Application;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Events.Handlers.Customers
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        public Task HandleAsync(CustomerCreatedEvent evt)
        {
            return Task.CompletedTask;
        }
    }
}
