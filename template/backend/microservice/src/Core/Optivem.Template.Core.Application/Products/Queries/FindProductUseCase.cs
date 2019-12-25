using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class FindProductUseCase : IRequestHandler<FindProductRequest, FindProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;

        public FindProductUseCase(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<FindProductResponse> HandleAsync(FindProductRequest request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productReadRepository.FindAsync(productId);

            if (product == null)
            {
                throw new NotFoundRequestException();
            }

            return _mapper.Map<Product, FindProductResponse>(product);
        }
    }
}