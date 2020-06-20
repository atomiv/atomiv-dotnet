using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Customers
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}