using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Products
{
    public class ProductFactory : IProductFactory
    {
        private const bool CreatedProductIsListed = true;

        private readonly IGenerator<ProductIdentity> _productIdentityGenerator;

        public ProductFactory(IGenerator<ProductIdentity> productIdentityGenerator)
        {
            _productIdentityGenerator = productIdentityGenerator;
        }

        public Product CreateProduct(string productCode, string productName, decimal listPrice)
        {
            var id = _productIdentityGenerator.Next();
            return new Product(id, productCode, productName, listPrice, CreatedProductIsListed);
        }
    }
}