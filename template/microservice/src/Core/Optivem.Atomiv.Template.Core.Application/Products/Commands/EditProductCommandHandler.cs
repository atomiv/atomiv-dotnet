using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Products.Commands
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, EditProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public EditProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<EditProductCommandResponse> HandleAsync(EditProductCommand request)
        {
            var productId = new ProductIdentity(request.Id);

            var product = await _productRepository.FindAsync(productId);

            Update(product, request);

            await _productRepository.UpdateAsync(product);

            var response = _mapper.Map<Product, EditProductCommandResponse>(product);
            return response;
        }

        private void Update(Product product, EditProductCommand request)
        {
            product.ProductName = request.Description;
            product.ListPrice = request.UnitPrice;
        }
    }
}