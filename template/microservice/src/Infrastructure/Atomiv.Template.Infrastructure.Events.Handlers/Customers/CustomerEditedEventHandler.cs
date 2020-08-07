using Atomiv.Core.Application;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Events.Handlers.Customers
{
    public class CustomerEditedEventHandler : IEventHandler<CustomerEditedEvent>
    {
        public Task HandleAsync(CustomerEditedEvent evt)
        {
            return Task.CompletedTask;
        }
    }
}
