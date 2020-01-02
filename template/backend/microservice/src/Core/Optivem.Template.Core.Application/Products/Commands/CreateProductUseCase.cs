using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class CreateProductUseCase : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IProductFactory _productFactory;

        public CreateProductUseCase(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository, IProductFactory productFactory)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

        public async Task<CreateProductCommandResponse> HandleAsync(CreateProductCommand request)
        {
            var product = GetProduct(request);

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Product, CreateProductCommandResponse>(product);
        }

        private Product GetProduct(CreateProductCommand request)
        {
            var productCode = request.Code;
            var productName = request.Description;
            var listPrice = request.UnitPrice;

            return _productFactory.CreateNewProduct(productCode, productName, listPrice);
        }
    }
}