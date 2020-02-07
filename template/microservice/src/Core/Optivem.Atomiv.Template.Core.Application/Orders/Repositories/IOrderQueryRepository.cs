using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Repositories
{
    public interface IOrderQueryRepository : IRepository
    {
        Task<BrowseOrdersQueryResponse> QueryAsync(BrowseOrdersQuery query);

        Task<FilterOrdersQueryResponse> QueryAsync(FilterOrdersQuery query);

        Task<ViewOrderQueryResponse> QueryAsync(ViewOrderQuery query);
    }
}
