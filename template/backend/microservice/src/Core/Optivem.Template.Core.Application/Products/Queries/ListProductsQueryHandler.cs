using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductQuery, ListProductsQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;

        public ListProductsQueryHandler(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<ListProductsQueryResponse> HandleAsync(ListProductQuery request)
        {
            var listResult = await _productReadRepository.ListAsync();

            return _mapper.Map<ListReadModel<ProductIdNameReadModel>, ListProductsQueryResponse>(listResult);
        }
    }
}