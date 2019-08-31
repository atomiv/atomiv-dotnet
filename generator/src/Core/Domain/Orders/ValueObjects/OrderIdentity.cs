using Optivem.Framework.Core.Domain;

namespace Optivem.Generator.Core.Domain.Orders.ValueObjects
{
    public class OrderIdentity : Identity<int>
    {
        public OrderIdentity(int id) : base(id)
        {
        }
    }
}
