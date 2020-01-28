using Optivem.Atomiv.Core.Domain;
using Optivem.Template.Core.Application.Customers.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.Repositories
{
    // TODO: VC: Base read repository, not related to domain
    public interface ICustomerReadRepository : IRepository
    {
        Task<BrowseCustomersQueryResponse> QueryAsync(BrowseCustomersQuery query);

        Task<FindCustomerQueryResponse> QueryAsync(FindCustomerQuery query);

        Task<ListCustomersQueryResponse> QueryAsync(ListCustomersQuery query);

        Task<bool> ExistsAsync(Guid customerId);

        Task<long> CountAsync();
    }
}
