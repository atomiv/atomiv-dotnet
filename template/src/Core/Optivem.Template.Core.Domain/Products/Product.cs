using System;
using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class Product : AggregateRoot<ProductIdentity>
    {
        public Product(ProductIdentity id, string productCode, string productName, decimal listPrice)
            : base(id)
        {
            ProductCode = productCode;
            ProductName = productName;
            ListPrice = listPrice;
            IsActive = true;
        }

        public string ProductCode { get; }

        public string ProductName { get; set; }

        public decimal ListPrice { get; set; }

        public bool IsActive { get; private set; }

        public void Activate()
        {
            if(IsActive)
            {
                throw new DomainException("Cannot activate product because it is already active");
            }

            IsActive = true;
        }

        public void Deactivate()
        {
            if(!IsActive)
            {
                throw new DomainException("Cannot deactivate product because it has already been deactivated");
            }

            IsActive = false;
        }
    }
}