using Atomiv.Core.Application;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Events.Handlers.Customers
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        public Task HandleAsync(CustomerCreatedEvent evt)
        {
            // TODO: Send email: Thanks for becoming our new customer
            return Task.CompletedTask;

            // additional implementations of IEventHandler<CustomerCreatedEvent>
        }
    }
}
