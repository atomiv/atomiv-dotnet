using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Domain.Products.Entities;
using Optivem.Generator.Core.Domain.Products.ValueObjects;

namespace Optivem.Generator.Core.Domain.Products.Repositories
{
    public interface IProductRepository : ICrudRepository<Product, ProductIdentity>, IPageAggregatesRepository<Product, ProductIdentity>
    {
    }
}