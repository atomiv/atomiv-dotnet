using Optivem.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductRepository : ICrudRepository<Product, ProductIdentity>
    {
    }
}