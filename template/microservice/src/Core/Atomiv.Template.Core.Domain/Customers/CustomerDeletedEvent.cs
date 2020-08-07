using Atomiv.Core.Domain;

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
