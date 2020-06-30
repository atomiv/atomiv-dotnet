namespace Atomiv.Template.Core.Domain.Products
{
    public interface IReadonlyProduct
    {
        public ProductIdentity Id { get; }

        public string ProductCode { get; }

        public string ProductName { get; }

        public decimal ListPrice { get; }

        public bool IsListed { get; }
    }
}
