using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Products
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IRequestHandler requestHandler) 
            : base(requestHandler)
        {
        }

        public Task<ActivateProductResponse> ActivateProductAsync(ActivateProductRequest request)
        {
            return HandleAsync<ActivateProductRequest, ActivateProductResponse>(request);
        }

        public Task<BrowseProductsResponse> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return HandleAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            return HandleAsync<CreateProductRequest, CreateProductResponse>(request);
        }

        public Task<DeactivateProductResponse> DeactivateProductAsync(DeactivateProductRequest request)
        {
            return HandleAsync<DeactivateProductRequest, DeactivateProductResponse>(request);
        }

        public Task<FindProductResponse> FindProductAsync(FindProductRequest request)
        {
            return HandleAsync<FindProductRequest, FindProductResponse>(request);
        }

        public Task<ListProductsResponse> ListProductsAsync(ListProductsRequest request)
        {
            return HandleAsync<ListProductsRequest, ListProductsResponse>(request);
        }

        public Task<UpdateProductResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            return HandleAsync<UpdateProductRequest, UpdateProductResponse>(request);
        }
    }
}
