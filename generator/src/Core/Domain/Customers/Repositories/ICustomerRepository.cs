using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Domain.Customers.Entities;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Domain.Customers.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}