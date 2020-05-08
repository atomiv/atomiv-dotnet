using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Products.Commands
{
    public class SyncProductsCommandHandler : IRequestHandler<SyncProductsCommand, SyncProductsCommandResponse>
    {
        private readonly IProductProviderService _productProviderService;
        private readonly IProductRepository _productRepository;

        public SyncProductsCommandHandler(IProductProviderService productProviderService,
            IProductRepository productRepository)
        {
            _productProviderService = productProviderService;
            _productRepository = productRepository;
        }

        public async Task<SyncProductsCommandResponse> HandleAsync(SyncProductsCommand request)
        {
            var products = await _productProviderService.GetProductsAsync();

            await _productRepository.SyncAsync(products);

            return new SyncProductsCommandResponse();
        }
    }
}
