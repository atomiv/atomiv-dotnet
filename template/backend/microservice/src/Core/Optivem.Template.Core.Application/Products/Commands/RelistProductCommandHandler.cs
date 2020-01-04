using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class RelistProductCommandHandler : IRequestHandler<RelistProductCommand, RelistProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public RelistProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<RelistProductCommandResponse> HandleAsync(RelistProductCommand request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productRepository.FindAsync(productId);

            product.Relist();

            await _productRepository.UpdateAsync(product);
            return _mapper.Map<Product, RelistProductCommandResponse>(product);
        }
    }
}