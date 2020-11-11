using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Customers
{
    public class CustomerReadonlyRepository : Repository, ICustomerReadonlyRepository
    {
        public CustomerReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            return Context.Customers.AsNoTracking()
                .AnyAsync(e => e.Id == customerId);
        }

        public Task<long> CountAsync()
        {
            return Context.Customers
                .LongCountAsync();
        }
    }
}
