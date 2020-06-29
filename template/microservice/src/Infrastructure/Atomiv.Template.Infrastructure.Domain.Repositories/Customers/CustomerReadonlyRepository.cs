using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System.Threading.Tasks;
using Atomiv.Template.Infrastructure.Domain.Persistence;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Customers
{
    public class CustomerReadonlyRepository : Repository, ICustomerReadonlyRepository
    {
        public CustomerReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.TryToGuid();

            if(customerRecordId == null)
            {
                return Task.FromResult(false);
            }

            return Context.Customers.AsNoTracking()
                .AnyAsync(e => e.Id == customerRecordId);
        }

        public Task<long> CountAsync()
        {
            return Context.Customers
                .LongCountAsync();
        }
    }
}
