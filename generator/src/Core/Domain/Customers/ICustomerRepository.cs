using Optivem.Framework.Core.Domain;

namespace Optivem.Generator.Core.Domain.Customers
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}