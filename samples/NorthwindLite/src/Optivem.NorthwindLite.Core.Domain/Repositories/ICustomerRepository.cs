using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;

namespace Optivem.NorthwindLite.Core.Domain.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}