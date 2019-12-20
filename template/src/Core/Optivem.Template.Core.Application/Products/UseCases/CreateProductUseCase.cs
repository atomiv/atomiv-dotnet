using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class CreateProductUseCase : IRequestHandler<CreateProductRequest, CreateProductResponse>
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

        public async Task<CreateProductResponse> HandleAsync(CreateProductRequest request)
        {
            var product = GetProduct(request);

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Product, CreateProductResponse>(product);
        }

        private Product GetProduct(CreateProductRequest request)
        {
            var productCode = request.Code;
            var productName = request.Description;
            var listPrice = request.UnitPrice;

            return _productFactory.CreateNewProduct(productCode, productName, listPrice);
        }
    }
}