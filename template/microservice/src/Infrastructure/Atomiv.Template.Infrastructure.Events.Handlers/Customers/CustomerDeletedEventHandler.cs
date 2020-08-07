using Atomiv.Core.Application;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Events.Handlers.Customers
{
    public class CustomerDeletedEventHandler : IEventHandler<CustomerDeletedEvent>
    {
        public Task HandleAsync(CustomerDeletedEvent evt)
        {
            return Task.CompletedTask;
        }
    }
}
