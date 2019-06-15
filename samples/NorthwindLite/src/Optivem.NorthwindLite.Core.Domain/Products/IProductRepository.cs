using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Products
{
    public interface IProductRepository : ICrudRepository<Product, ProductIdentity>
    {
    }
}