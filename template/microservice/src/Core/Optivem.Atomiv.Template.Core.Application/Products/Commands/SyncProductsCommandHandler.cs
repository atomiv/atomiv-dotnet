using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Products.Commands
{
    public class SyncProductsCommandHandler : IRequestHandler<SyncProductsCommand, SyncProductsCommandResponse>
    {
        // private readonly IProductProviderService _productProviderService;
        private readonly IProductRepository _productRepository;
        private readonly IProductFactory _productFactory;

        public SyncProductsCommandHandler(/* IProductProviderService productProviderService, */
            IProductRepository productRepository,
            IProductFactory productFactory)
        {
            // _productProviderService = productProviderService;
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

        public async Task<SyncProductsCommandResponse> HandleAsync(SyncProductsCommand request)
        {
            // var products = await _productProviderService.GetProductsAsync();

            var product1 = _productFactory.CreateNewProduct("ABC", "Product ABC", 45.56m);
            var product2 = _productFactory.CreateNewProduct("DEF", "Product DEF", 56.78m);

            var products = new List<Product>
            {
                product1,
                product2,
            };

            await _productRepository.SyncAsync(products);

            return new SyncProductsCommandResponse();
        }
    }
}
