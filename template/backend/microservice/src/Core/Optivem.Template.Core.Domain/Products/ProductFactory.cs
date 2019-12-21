using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductFactory : IProductFactory
    {
        private const bool DefaultIsListed = true;

        private readonly IIdentityGenerator<ProductIdentity> _productIdentityGenerator;

        public ProductFactory(IIdentityGenerator<ProductIdentity> productIdentityGenerator)
        {
            _productIdentityGenerator = productIdentityGenerator;
        }

        public Product CreateNewProduct(string productCode, string productName, decimal listPrice)
        {
            var id = _productIdentityGenerator.Next();
            return new Product(id, productCode, productName, listPrice, DefaultIsListed);
        }
    }
}