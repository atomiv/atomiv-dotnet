using Optivem.Framework.Core.Domain;

namespace Optivem.Generator.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<int>
    {
        public static readonly CustomerIdentity Null = new CustomerIdentity(0);

        public CustomerIdentity(int id) : base(id)
        {
        }
    }
}
