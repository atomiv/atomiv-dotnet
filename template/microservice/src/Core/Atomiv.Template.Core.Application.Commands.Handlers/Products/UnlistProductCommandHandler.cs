using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Products
{
    public class UnlistProductCommandHandler : ICommandHandler<UnlistProductCommand, UnlistProductCommandResponse>
    {
        private readonly IValidator<Product> _productValidator;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnlistProductCommandHandler(IValidator<Product> productValidator,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _productValidator = productValidator;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UnlistProductCommandResponse> HandleAsync(UnlistProductCommand command)
        {
            var productId = new ProductIdentity(command.Id);

            var product = await _productRepository.FindAsync(productId);

            if(product == null)
            {
                throw new ExistenceException();
            }

            product.Unlist();

            var validationResult = await _productValidator.ValidateAsync(product);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            await _productRepository.UpdateAsync(product);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Product, UnlistProductCommandResponse>(product);
        }
    }
}