using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public class ProductService : ApplicationService, IProductService
    {
        public ProductService(IRequestHandler requestHandler)
            : base(requestHandler)
        {
        }

        public Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request)
        {
            return HandleAsync<RelistProductRequest, RelistProductResponse>(request);
        }

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return HandleAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            return HandleAsync<CreateProductRequest, CreateProductResponse>(request);
        }

        public Task<FindProductResponse> FindProductAsync(FindProductRequest request)
        {
            return HandleAsync<FindProductRequest, FindProductResponse>(request);
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductRequest request)
        {
            return HandleAsync<ListProductRequest, ListProductsResponse>(request);
        }

        public Task<UnlistProductResponse> UnlistProductAsync(UnlistProductRequest request)
        {
            return HandleAsync<UnlistProductRequest, UnlistProductResponse>(request);
        }

        public Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            return HandleAsync<UpdateProductRequest, UpdateProductResponse>(request);
        }
    }
}