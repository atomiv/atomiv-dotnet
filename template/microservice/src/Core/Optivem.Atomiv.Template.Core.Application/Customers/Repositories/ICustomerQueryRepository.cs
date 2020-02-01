using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Repositories
{
    // TODO: VC: Base read repository, not related to domain
    public interface ICustomerQueryRepository : IRepository
    {
        Task<BrowseCustomersQueryResponse> QueryAsync(BrowseCustomersQuery query);

        Task<ListCustomersQueryResponse> QueryAsync(ListCustomersQuery query);

        Task<ViewCustomerQueryResponse> QueryAsync(ViewCustomerQuery query);
    }
}
