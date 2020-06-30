using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderItemIdentity : Identity<string>
    {
        public OrderItemIdentity(string value)
            : base(value)
        {
        }
    }
}