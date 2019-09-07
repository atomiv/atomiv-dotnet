using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderDetailIdentity : Identity<int>
    {
        public OrderDetailIdentity(int id) 
            : base(id)
        {
        }
    }
}
