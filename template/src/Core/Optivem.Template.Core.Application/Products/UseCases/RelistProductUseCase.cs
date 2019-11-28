using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class RelistProductUseCase : RequestHandler<RelistProductRequest, RelistProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public RelistProductUseCase(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public override async Task<RelistProductResponse> HandleAsync(RelistProductRequest request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productRepository.FindAsync(productId);

            if (product == null)
            {
                throw new NotFoundRequestException();
            }

            product.Relist();

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return Mapper.Map<Product, RelistProductResponse>(product);
        }
    }
}