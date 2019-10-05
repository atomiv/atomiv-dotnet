using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductRepository : IRepository<Product, ProductIdentity>,
        IFindAggregateRootRepository<Product, ProductIdentity>,
        IExistsAggregateRootRepository<Product, ProductIdentity>,
        IAddAggregateRootRepository<Product, ProductIdentity>,
        IUpdateAggregateRootRepository<Product, ProductIdentity>,
        IRemoveAggregateRootRepository<Product, ProductIdentity>,
        IPageAggregateRootsRepository<Product, ProductIdentity>,
        IListAggregateRootsRepository<Product, ProductIdentity>
    {
    }
}