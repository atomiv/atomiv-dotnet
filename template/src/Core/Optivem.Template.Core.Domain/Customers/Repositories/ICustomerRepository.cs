using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers.Entities;
using Optivem.Template.Core.Domain.Customers.ValueObjects;

namespace Optivem.Template.Core.Domain.Customers.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}