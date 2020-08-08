using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Products
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductFactory _productFactory;
        private readonly IValidator<Product> _productValidator;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductFactory productFactory,
            IValidator<Product> productValidator,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _productFactory = productFactory;
            _productValidator = productValidator;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> HandleAsync(CreateProductCommand command)
        {
            var product = GetProduct(command);

            await _productRepository.AddAsync(product);

            var validationResult = await _productValidator.ValidateAsync(product);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Product, CreateProductCommandResponse>(product);
        }

        private Product GetProduct(CreateProductCommand request)
        {
            var productCode = request.Code;
            var productName = request.Description;
            var listPrice = request.UnitPrice;

            return _productFactory.CreateProduct(productCode, productName, listPrice);
        }
    }
}