using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Products
{
    public interface IProductRepository : ICrudRepository<Product, ProductIdentity>, IPageAggregatesRepository<Product, ProductIdentity>
    {
    }
}