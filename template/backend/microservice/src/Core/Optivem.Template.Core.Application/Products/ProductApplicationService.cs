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

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return HandleAsync(request);
        }

        public Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            return HandleAsync(request);
        }

        public Task<FindProductResponse> FindProductAsync(FindProductRequest request)
        {
            return HandleAsync(request);
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductRequest request)
        {
            return HandleAsync(request);
        }

        public Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request)
        {
            return HandleAsync(request);
        }

        public Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request)
        {
            return HandleAsync(request);
        }

        public Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            return HandleAsync(request);
        }
    }
}