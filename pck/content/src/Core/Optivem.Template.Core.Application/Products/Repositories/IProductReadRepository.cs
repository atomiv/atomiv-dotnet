using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Repositories
{
    public interface IProductReadRepository : IRepository
    {
        Task<BrowseProductsQueryResponse> QueryAsync(BrowseProductsQuery query);

        Task<FindProductQueryResponse> QueryAsync(FindProductQuery query);

        Task<ListProductsQueryResponse> QueryAsync(ListProductsQuery query);

        Task<bool> ExistsAsync(Guid productId);

        Task<long> CountAsync();

        Task<decimal?> GetPriceAsync(Guid productId);
    }
}
