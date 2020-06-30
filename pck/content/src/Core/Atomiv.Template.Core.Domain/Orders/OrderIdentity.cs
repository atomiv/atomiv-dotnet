using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Orders
{
    public class OrderIdentity : Identity<string>
    {
        public OrderIdentity(string value) : base(value)
        {
        }
    }
}