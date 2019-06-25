using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products.Entities;
using Optivem.Template.Core.Domain.Products.ValueObjects;

namespace Optivem.Template.Core.Domain.Products.Repositories
{
    public interface IProductRepository : ICrudRepository<Product, ProductIdentity>
    {
    }
}