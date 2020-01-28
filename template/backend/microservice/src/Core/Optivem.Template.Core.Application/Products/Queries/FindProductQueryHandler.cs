using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Template.Core.Application.Products.Repositories;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class FindProductQueryHandler : IRequestHandler<FindProductQuery, FindProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public FindProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<FindProductQueryResponse> HandleAsync(FindProductQuery request)
        {
            var response = await _productReadRepository.QueryAsync(request);

            return response;
        }
    }
}