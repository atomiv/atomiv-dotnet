using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
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
            throw new NotImplementedException();

            /*
            return Context.Customers
                .CountDocumentsAsync(e => true);
            */
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            throw new NotImplementedException();
        }
    }
}
