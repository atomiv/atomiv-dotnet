using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Queries.Repositories
{
    public interface IOrderReadRepository : IRepository
    {
        Task<BrowseOrdersQueryResponse> QueryAsync(BrowseOrdersQuery query);

        Task<FindOrderQueryResponse> QueryAsync(FindOrderQuery query);

        Task<ListOrdersQueryResponse> QueryAsync(ListOrdersQuery query);
        
        Task<bool> ExistsAsync(Guid orderId);

        Task<long> CountAsync();
    }
}
