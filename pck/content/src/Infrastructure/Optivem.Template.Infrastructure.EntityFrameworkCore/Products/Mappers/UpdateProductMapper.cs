using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Mappers
{
    public class UpdateProductMapper : IUpdateAggregateRootMapper<Product, ProductRecord>
    {
        public ProductRecord Map(Product product, ProductRecord productRecord)
        {
            var id = product.Id.Id;
            var productCode = product.ProductCode;
            var productName = product.ProductName;
            var listPrice = product.ListPrice;
            var isActive = product.IsActive;

            productRecord.Id = id;
            productRecord.ProductCode = productCode;
            productRecord.ProductName = productName;
            productRecord.ListPrice = listPrice;
            productRecord.IsActive = isActive;

            return productRecord;
        }
    }
}
