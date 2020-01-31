using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Products.Queries
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, ListProductsQueryResponse>
    {
        private readonly IProductQueryRepository _productReadRepository;

        public ListProductsQueryHandler(IProductQueryRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public Task<ListProductsQueryResponse> HandleAsync(ListProductsQuery request)
        {
            return _productReadRepository.QueryAsync(request);
        }
    }
}