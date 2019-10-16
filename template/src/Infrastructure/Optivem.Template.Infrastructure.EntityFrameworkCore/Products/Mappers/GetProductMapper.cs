using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Mappers
{
    public class GetProductMapper : IGetAggregateRootMapper<Product, ProductRecord>
    {
        public Product Create(ProductRecord productRecord)
        {
            var id = new ProductIdentity(productRecord.Id);
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductName;
            var listPrice = productRecord.ListPrice;
            var isActive = productRecord.IsActive;

            return new Product(id, productCode, productName, listPrice, isActive);
        }

        public List<Expression<Func<ProductRecord, object>>> GetIncludes()
        {
            return null;
        }
    }
}