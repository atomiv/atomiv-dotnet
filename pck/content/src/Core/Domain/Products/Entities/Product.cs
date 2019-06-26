using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Products.Entities
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
