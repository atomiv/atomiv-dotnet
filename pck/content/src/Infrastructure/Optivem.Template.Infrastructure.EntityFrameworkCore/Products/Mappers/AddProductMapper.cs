using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Mappers
{
    public class AddProductMapper : IAddAggregateRootMapper<Product, ProductRecord>
    {
        public ProductRecord Map(Product product)
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