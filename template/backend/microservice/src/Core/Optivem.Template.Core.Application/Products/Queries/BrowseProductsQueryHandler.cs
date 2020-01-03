using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Repositories;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class BrowseProductsQueryHandler : IRequestHandler<BrowseProductsQuery, BrowseProductsQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public BrowseProductsQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public Task<BrowseProductsQueryResponse> HandleAsync(BrowseProductsQuery request)
        {
            return _productReadRepository.QueryAsync(request);
        }
    }
}