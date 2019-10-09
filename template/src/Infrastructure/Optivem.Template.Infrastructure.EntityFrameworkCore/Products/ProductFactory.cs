using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductFactory : IAggregateRootFactory<Product, ProductRecord>
    {
        public Product Create(ProductRecord record)
        {
            var identity = new ProductIdentity(record.Id);
            var productCode = record.ProductCode;
            var productName = record.ProductName;
            var listPrice = record.ListPrice;

            return new Product(identity, productCode, productName, listPrice);
        }
    }
}
