using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Mappers
{
    public class AddProductMapper : IAddAggregateRootMapper<Product, ProductRecord>
    {
        public ProductRecord Create(Product product)
        {
            var id = product.Id.Id;
            var productCode = product.ProductCode;
            var productName = product.ProductName;
            var listPrice = product.ListPrice;
            var isActive = product.IsActive;

            return new ProductRecord
            {
                Id = id,
                ProductCode = productCode,
                ProductName = productName,
                ListPrice = listPrice,
                IsActive = isActive,
            };
        }
    }
}
