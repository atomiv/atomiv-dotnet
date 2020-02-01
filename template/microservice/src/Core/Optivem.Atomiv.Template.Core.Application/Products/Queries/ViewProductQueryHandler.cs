using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Products.Queries
{
    public class ViewProductQueryHandler : IRequestHandler<ViewProductQuery, ViewProductQueryResponse>
    {
        private readonly IProductQueryRepository _productReadRepository;

        public ViewProductQueryHandler(IProductQueryRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<ViewProductQueryResponse> HandleAsync(ViewProductQuery request)
        {
            var response = await _productReadRepository.QueryAsync(request);

            return response;
        }
    }
}