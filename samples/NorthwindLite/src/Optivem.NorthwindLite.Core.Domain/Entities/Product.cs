using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Domain.Identities;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class Product : AggregateRoot<ProductIdentity>
    {
        public Product(ProductIdentity id, string productCode, string productName, decimal listPrice)
            : base(id)
        {
            ProductCode = productCode;
            ProductName = productName;
            ListPrice = listPrice;
        }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal ListPrice { get; set; }
    }
}