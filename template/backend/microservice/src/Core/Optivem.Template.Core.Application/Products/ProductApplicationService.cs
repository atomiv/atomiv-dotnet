using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public class ProductApplicationService : ApplicationService, IProductApplicationService
    {
        public ProductApplicationService(IRequestHandler requestHandler)
            : base(requestHandler)
        {
        }

        public Task<BrowseProductsQueryResponse> BrowseProductsAsync(BrowseProductsQuery request)
        {
            return HandleAsync(request);
        }

        public Task<CreateProductCommandResponse> CreateProductAsync(CreateProductCommand request)
        {
            return HandleAsync(request);
        }

        public Task<FindProductQueryResponse> FindProductAsync(FindProductQuery request)
        {
            return HandleAsync(request);
        }

        public Task<ListProductsQueryResponse> ListProductsAsync(ListProductQuery request)
        {
            return HandleAsync(request);
        }

        public Task<RelistProductCommandResponse> RelistProductAsync(RelistProductCommand request)
        {
            return HandleAsync(request);
        }

        public Task<UnlistProductCommandResponse> UnlistProductAsync(UnlistProductCommand request)
        {
            return HandleAsync(request);
        }

        public Task<UpdateProductCommandResponse> UpdateProductAsync(UpdateProductCommand request)
        {
            return HandleAsync(request);
        }
    }
}