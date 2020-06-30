using System.Threading.Tasks;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Products
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

            if(product == null)
            {
                throw new ExistenceException();
            }

            product.Relist();

            await _productRepository.UpdateAsync(product);
            return _mapper.Map<Product, RelistProductCommandResponse>(product);
        }
    }
}