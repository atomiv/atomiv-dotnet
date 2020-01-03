using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Queries.Repositories
{
    public interface IProductReadRepository : IRepository
    {
        Task<BrowseProductsQueryResponse> QueryAsync(BrowseProductsQuery query);

        Task<FindProductQueryResponse> QueryAsync(FindProductQuery query);

        Task<ListProductsQueryResponse> QueryAsync(ListProductsQueryResponse query);
    }
}
