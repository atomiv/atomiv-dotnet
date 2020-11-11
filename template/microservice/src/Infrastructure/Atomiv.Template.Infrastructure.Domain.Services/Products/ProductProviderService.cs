using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Services.Products
{
    public class ProductProviderService : IProductProviderService
    {
        private static List<ProductRecord> FakeData = new List<ProductRecord>
        {
            new ProductRecord { ProductCode = "ABC", ProductDescription = "Product ABC", Price = 45.56m },
            new ProductRecord { ProductCode = "DEF", ProductDescription = "Product DEF", Price = 56.78m },
        };

        private readonly IProductFactory _productFactory;
        private readonly IProductRepository _productRepository;

        public ProductProviderService(IProductFactory productFactory,
            IProductRepository productReadonlyRepository)
        {
            _productFactory = productFactory;
            _productRepository = productReadonlyRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            // TODO: VC: Sample reading from DB, then also reading from web service etc.
            // and then combine those product lists together

            var products = new List<Product>();

            foreach(var productRecord in FakeData)
            {
                var product = await GetProductAsync(productRecord);
                products.Add(product);
            }

            return products;
        }

        private async Task<Product> GetProductAsync(ProductRecord productRecord)
        {
            var productCode = productRecord.ProductCode;
            var productName = productRecord.ProductDescription;
            var listPrice = productRecord.Price;

            var product = await _productRepository.FindAsync(productCode);

            if(product == null)
            {
                product = _productFactory.CreateProduct(productCode, productName, listPrice);
            }
            else
            {
                product.ProductName = productName;
                product.ListPrice = listPrice;
            }

            return product;
        }

        private class ProductRecord
        {
            public string ProductCode { get; set; }

            public string ProductDescription { get; set; }

            public decimal Price { get; set; }
        }
    }
}
