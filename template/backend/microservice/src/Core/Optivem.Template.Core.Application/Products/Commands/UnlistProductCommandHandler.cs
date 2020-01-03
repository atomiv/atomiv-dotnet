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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public UnlistProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<UnlistProductCommandResponse> HandleAsync(UnlistProductCommand request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productRepository.FindAsync(productId);

            if (product == null)
            {
                throw new NotFoundRequestException();
            }

            product.Unlist();

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Product, UnlistProductCommandResponse>(product);
        }
    }
}