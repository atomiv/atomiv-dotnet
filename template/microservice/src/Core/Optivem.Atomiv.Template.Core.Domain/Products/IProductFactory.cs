using Optivem.Atomiv.Core.Domain;

namespace Optivem.Atomiv.Template.Core.Domain.Products
{
    public interface IProductFactory : IFactory
    {
        Product CreateNewProduct(string productCode, string productName, decimal listPrice);
    }
}
