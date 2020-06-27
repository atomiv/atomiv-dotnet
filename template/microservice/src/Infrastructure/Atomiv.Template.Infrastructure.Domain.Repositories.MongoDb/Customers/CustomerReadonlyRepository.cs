using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.Customers
{
    public class CustomerReadonlyRepository : Repository, ICustomerReadonlyRepository
    {
        public CustomerReadonlyRepository(MongoDbContext context) : base(context)
        {
        }

        public Task<long> CountAsync()
        {
            return Context.Customers
                .CountDocumentsAsync();
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.TryToObjectId();

            if (customerRecordId == null)
            {
                return Task.FromResult(false);
            }

            return Context.Customers
                .Find(e => e.Id == customerRecordId)
                .AnyAsync();
        }
    }
}
