using Atomiv.Core.Application;
using Atomiv.Core.Application.Services;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using System.Threading.Tasks;

namespace Generator.Core.Application.Products
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IRequestHandler requestHandler) 
            : base(requestHandler)
        {
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

        public Task<ListProductsResponse> ListProductsAsync(ListProductsRequest request)
        {
            return HandleAsync<ListProductsRequest, ListProductsResponse>(request);
        }

        public Task<RelistProductResponse> RelistProductAsync(RelistProductRequest request)
        {
            return HandleAsync<RelistProductRequest, RelistProductResponse>(request);
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
