using Optivem.Atomiv.Core.Domain;

namespace Optivem.Generator.Core.Domain.Customers
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}