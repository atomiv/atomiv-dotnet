namespace Optivem.Template.Core.Domain.Products
{
    public class ProductFactory
    {
        private const bool DefaultIsListed = true;

        public static Product CreateNewProduct(string productCode, string productName, decimal listPrice)
        {
            return new Product(ProductIdentity.Null, productCode, productName, listPrice, DefaultIsListed);
        }
    }
}