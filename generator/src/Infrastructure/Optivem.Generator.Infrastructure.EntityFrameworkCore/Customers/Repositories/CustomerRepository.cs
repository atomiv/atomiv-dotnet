using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Generator.Core.Domain.Customers;
using Optivem.Generator.Infrastructure.EntityFrameworkCore.Customers.Records;

namespace Optivem.Generator.Infrastructure.EntityFrameworkCore.Customers.Repositories
{
    public class CustomerRepository : Repository<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        protected override Customer GetAggregateRoot(CustomerRecord record)
        {
            var identity = new CustomerIdentity(record.Id);
            return new Customer(identity, record.FirstName, record.LastName);
        }

        protected override CustomerIdentity GetIdentity(CustomerRecord record)
        {
            return new CustomerIdentity(record.Id);
        }

        protected override CustomerRecord GetRecord(CustomerIdentity identity)
        {
            return new CustomerRecord
            {
                Id = identity.Id,
            };
        }

        protected override CustomerRecord GetRecord(Customer aggregateRoot)
        {
            return new CustomerRecord
            {
                Id = aggregateRoot.Id.Id,
                FirstName = aggregateRoot.FirstName,
                LastName = aggregateRoot.LastName,
                Order = null,
            };
        }
    }
}