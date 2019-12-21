using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class Product : Entity<ProductIdentity>
    {
        public Product(ProductIdentity id, string productCode, string productName, decimal listPrice, bool isListed)
            : base(id)
        {
            ProductCode = productCode;
            ProductName = productName;
            ListPrice = listPrice;
            IsListed = isListed;
        }

        public string ProductCode { get; }

        public string ProductName { get; set; }

        public decimal ListPrice { get; set; }

        public bool IsListed { get; private set; }

        public void Relist()
        {
            if (IsListed)
            {
                throw new DomainException("Cannot relist product because it is already listed");
            }

            IsListed = true;
        }

        public void Unlist()
        {
            if (!IsListed)
            {
                throw new DomainException("Cannot unlist product because it has already been unlisted");
            }

            IsListed = false;
        }
    }
}