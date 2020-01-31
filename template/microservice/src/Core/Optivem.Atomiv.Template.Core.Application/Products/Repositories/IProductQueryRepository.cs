using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Products.Repositories
{
    public interface IProductQueryRepository : IRepository
    {
        Task<BrowseProductsQueryResponse> QueryAsync(BrowseProductsQuery query);

        Task<FindProductQueryResponse> QueryAsync(FindProductQuery query);

        Task<ListProductsQueryResponse> QueryAsync(ListProductsQuery query);

        Task<bool> ExistsAsync(Guid productId);

        Task<long> CountAsync();

        Task<decimal?> GetPriceAsync(Guid productId);
    }
}
