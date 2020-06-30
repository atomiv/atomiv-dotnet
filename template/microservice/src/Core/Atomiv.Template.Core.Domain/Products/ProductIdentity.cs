using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Products
{
    public class ProductIdentity : Identity<string>
    {
        public ProductIdentity(string value)
            : base(value)
        {
        }
    }
}