using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class CreateProductUseCase : RequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public CreateProductUseCase(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public override async Task<CreateProductResponse> HandleAsync(CreateProductRequest request)
        {
            var product = GetProduct(request);

            product = await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return Mapper.Map<Product, CreateProductResponse>(product);
        }

        private Product GetProduct(CreateProductRequest request)
        {
            var productCode = request.Code;
            var productName = request.Description;
            var listPrice = request.UnitPrice;

            return ProductFactory.CreateNewProduct(productCode, productName, listPrice);
        }
    }
}