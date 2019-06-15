using Optivem.Core.Domain;

namespace Optivem.NorthwindLite.Core.Domain.Customers
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}