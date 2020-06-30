using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Products
{
    public interface IProductFactory : IFactory
    {
        Product CreateProduct(string productCode, string productName, decimal listPrice);
    }
}
