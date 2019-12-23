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

        public Task<ProductResponse> RelistProductAsync(RelistProductRequest request)
        {
            return HandleAsync<RelistProductRequest, ProductResponse>(request);
        }

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return HandleAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<ProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            return HandleAsync<CreateProductRequest, ProductResponse>(request);
        }

        public Task<FindProductResponse> FindProductAsync(FindProductRequest request)
        {
            return HandleAsync<FindProductRequest, FindProductResponse>(request);
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductRequest request)
        {
            return HandleAsync<ListProductRequest, ListProductsResponse>(request);
        }

        public Task<ProductResponse> UnlistProductAsync(UnlistProductRequest request)
        {
            return HandleAsync<UnlistProductRequest, ProductResponse>(request);
        }

        public Task<ProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            return HandleAsync<UpdateProductRequest, ProductResponse>(request);
        }
    }
}