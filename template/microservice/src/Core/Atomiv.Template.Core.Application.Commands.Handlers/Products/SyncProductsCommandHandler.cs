using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Products
{
    public class SyncProductsCommandHandler : ICommandHandler<SyncProductsCommand, SyncProductsCommandResponse>
    {
        private readonly IEnumerableValidator<Product> _productValidator;
        private readonly IProductProviderService _productProviderService;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SyncProductsCommandHandler(IEnumerableValidator<Product> productValidator,
            IProductProviderService productProviderService,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productValidator = productValidator;
            _productProviderService = productProviderService;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SyncProductsCommandResponse> HandleAsync(SyncProductsCommand command)
        {
            var products = await _productProviderService.GetProductsAsync();

            var validationResult = await _productValidator.ValidateAsync(products);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            await _productRepository.SyncAsync(products);

            await _unitOfWork.CommitAsync();

            return new SyncProductsCommandResponse();
        }
    }
}
