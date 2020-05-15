using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Repositories
{
    public interface ICustomerQueryRepository : IRepository
    {
        Task<BrowseCustomersQueryResponse> QueryAsync(BrowseCustomersQuery query);

        Task<FilterCustomersQueryResponse> QueryAsync(FilterCustomersQuery query);

        Task<ViewCustomerQueryResponse> QueryAsync(ViewCustomerQuery query);
    }
}
