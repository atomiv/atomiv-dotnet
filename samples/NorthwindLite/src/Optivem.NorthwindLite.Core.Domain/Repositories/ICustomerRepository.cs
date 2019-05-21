using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Core.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}