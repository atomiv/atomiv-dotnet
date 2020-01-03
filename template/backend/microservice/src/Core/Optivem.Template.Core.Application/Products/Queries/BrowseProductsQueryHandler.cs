using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class BrowseProductsQueryHandler : IRequestHandler<BrowseProductsQuery, BrowseProductsQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;

        public BrowseProductsQueryHandler(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<BrowseProductsQueryResponse> HandleAsync(BrowseProductsQuery request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _productReadRepository.GetPageAsync(pageQuery);

            return _mapper.Map<PageReadModel<ProductHeaderReadModel>, BrowseProductsQueryResponse>(pageResult);
        }
    }
}