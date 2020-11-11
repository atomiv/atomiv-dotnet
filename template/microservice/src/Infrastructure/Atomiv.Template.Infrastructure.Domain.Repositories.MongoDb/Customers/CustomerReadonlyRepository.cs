using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDB.Customers
{
    public class CustomerReadonlyRepository : Repository, ICustomerReadonlyRepository
    {
        public CustomerReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<long> CountAsync()
        {
            return Context.Customers
                .CountDocumentsAsync();
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            return Context.Customers
                .Find(e => e.Id == customerId)
                .AnyAsync();
        }
    }
}
