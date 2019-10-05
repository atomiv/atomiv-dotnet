using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerRepository 
        : IRepository<Customer, CustomerIdentity>,
        IFindAggregateRootRepository<Customer, CustomerIdentity>,
        IExistsAggregateRootRepository<Customer, CustomerIdentity>,
        IAddAggregateRootRepository<Customer, CustomerIdentity>,
        IUpdateAggregateRootRepository<Customer, CustomerIdentity>,
        IRemoveAggregateRootRepository<Customer, CustomerIdentity>,
        IPageAggregateRootsRepository<Customer, CustomerIdentity>,
        IListAggregateRootsRepository<Customer, CustomerIdentity>
    {
    }
}