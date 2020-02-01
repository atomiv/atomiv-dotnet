using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Products.Repositories
{
    public interface IProductQueryRepository : IRepository
    {
        Task<BrowseProductsQueryResponse> QueryAsync(BrowseProductsQuery query);

        Task<FilterProductsQueryResponse> QueryAsync(FilterProductsQuery query);

        Task<ViewProductQueryResponse> QueryAsync(ViewProductQuery query);
    }
}
