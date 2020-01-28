using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Template.Core.Application.Products.Repositories;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, ListProductsQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public ListProductsQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public Task<ListProductsQueryResponse> HandleAsync(ListProductsQuery request)
        {
            return _productReadRepository.QueryAsync(request);
        }
    }
}