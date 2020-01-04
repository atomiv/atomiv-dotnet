using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UnlistProductCommandHandler : IRequestHandler<UnlistProductCommand, UnlistProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UnlistProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<UnlistProductCommandResponse> HandleAsync(UnlistProductCommand request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productRepository.FindAsync(productId);

            product.Unlist();

            await _productRepository.UpdateAsync(product);
            return _mapper.Map<Product, UnlistProductCommandResponse>(product);
        }
    }
}