using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class UpdateProductUseCase : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public UpdateProductUseCase(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<UpdateProductResponse> HandleAsync(UpdateProductRequest request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productRepository.FindAsync(productId);

            if (product == null)
            {
                throw new NotFoundRequestException();
            }

            Update(product, request);

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            var response = _mapper.Map<Product, UpdateProductResponse>(product);
            return response;
        }

        private void Update(Product product, UpdateProductRequest request)
        {
            product.ProductName = request.Description;
            product.ListPrice = request.UnitPrice;
        }
    }
}