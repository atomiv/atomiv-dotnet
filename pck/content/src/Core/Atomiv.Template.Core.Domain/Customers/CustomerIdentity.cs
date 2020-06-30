using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<string>
    {
        public CustomerIdentity(string value) : base(value)
        {
        }
    }
}