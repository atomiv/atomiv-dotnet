using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers
{
    public class CustomerRepository : Repository<Customer, CustomerIdentity>, ICustomerRepository
    {
        public CustomerRepository(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<Customer> AddAsync(Customer aggregateRoot)
        {
            return HandleAddAggregateRootAsync(aggregateRoot);
        }

        public Task<bool> ExistsAsync(CustomerIdentity identity)
        {
            return HandleExistsAggregateRootAsync(identity);
        }

        public Task<Customer> FindAsync(CustomerIdentity identity)
        {
            return HandleFindAggregateRootAsync(identity);
        }

        public Task<IEnumerable<Customer>> ListAsync()
        {
            return HandleListAggregateRootsAsync();
        }

        public Task<PageAggregateRootsResponse<Customer>> PageAsync(int page, int size)
        {
            return HandlePageAggregateRootsAsync(page, size);
        }

        public Task RemoveAsync(CustomerIdentity identity)
        {
            return HandleRemoveAggregateRootAsync(identity);
        }

        public Task UpdateAsync(Customer aggregateRoot)
        {
            return HandleUpdateAggregateRootAsync(aggregateRoot);
        }
    }
}