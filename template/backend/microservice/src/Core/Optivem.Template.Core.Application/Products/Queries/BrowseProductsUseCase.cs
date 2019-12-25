using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class BrowseProductsUseCase : IRequestHandler<BrowseProductsRequest, BrowseProductsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;

        public BrowseProductsUseCase(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<BrowseProductsResponse> HandleAsync(BrowseProductsRequest request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _productReadRepository.GetPageAsync(pageQuery);

            return _mapper.Map<PageReadModel<ProductHeaderReadModel>, BrowseProductsResponse>(pageResult);
        }
    }
}