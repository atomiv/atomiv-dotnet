using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductFactory : IFactory
    {
        Product CreateNewProduct(string productCode, string productName, decimal listPrice);
    }
}
