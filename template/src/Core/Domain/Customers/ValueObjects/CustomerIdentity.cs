using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers.ValueObjects
{
    public class CustomerIdentity : Identity<int>
    {
        // TODO: VC: Handling null identity, sinc in most cases require id > 0
        // using the ordinary constructor, but only via Null it's 0
        // or should be use int? to indicate if set?

        public static readonly CustomerIdentity Null = new CustomerIdentity(0);

        public CustomerIdentity(int id) : base(id)
        {
        }
    }
}
