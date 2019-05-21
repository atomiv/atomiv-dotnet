using Optivem.Infrastructure.Persistence.EntityFrameworkCore;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Persistence
{
    public class CustomerRepository : Repository<DatabaseContext, Customer, int>
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
