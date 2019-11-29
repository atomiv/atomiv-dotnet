namespace Optivem.Template.Core.Domain.Products
{
    public class ProductFactory
    {
        private const bool DefaultIsListed = true;

        public static Product CreateNewProduct(string productCode, string productName, decimal listPrice)
        {
            var id = ProductIdentity.New();
            return new Product(id, productCode, productName, listPrice, DefaultIsListed);
        }
    }
}