namespace Optivem.Template.Core.Domain.Products
{
    public class ProductHeaderReadModel
    {
        public ProductHeaderReadModel(ProductIdentity id, string productCode, string productName, decimal listPrice, bool isListed)
        {
            ProductId = id;
            ProductCode = productCode;
            ProductName = productName;
            ListPrice = listPrice;
            IsListed = isListed;
        }

        public ProductIdentity ProductId { get; }

        public string ProductCode { get; }

        public string ProductName { get; }

        public decimal ListPrice { get; }

        public bool IsListed { get; }
    }
}
