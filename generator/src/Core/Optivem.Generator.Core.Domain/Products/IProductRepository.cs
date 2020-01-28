using Optivem.Atomiv.Core.Domain;

namespace Optivem.Generator.Core.Domain.Products
{
    public interface IProductRepository : ICrudRepository<Product, ProductIdentity>, IPageAggregatesRepository<Product, ProductIdentity>
    {
    }
}