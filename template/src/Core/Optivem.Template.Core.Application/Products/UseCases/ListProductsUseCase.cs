using System.Threading.Tasks;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class ListProductsUseCase : IRequestHandler<ListProductRequest, ListProductsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;

        public ListProductsUseCase(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<ListProductsResponse> HandleAsync(ListProductRequest request)
        {
            var listResult = await _productReadRepository.ListAsync();

            return _mapper.Map<ListReadModel<ProductIdNameReadModel>, ListProductsResponse>(listResult);
        }
    }
}