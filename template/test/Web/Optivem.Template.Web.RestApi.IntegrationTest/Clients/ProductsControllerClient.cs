using Optivem.Core.Common.Http;
using Optivem.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Products;
using System.Threading.Tasks;

namespace Optivem.Template.Web.IntegrationTest.Clients
{
    public class ProductsControllerClient : BaseControllerClient
    {
        public ProductsControllerClient(IControllerClientFactory clientFactory)
            : base(clientFactory, "api/products")
        {
        }

        public Task<IObjectClientResponse<BrowseProductsResponse>> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return Client.GetAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<IObjectClientResponse<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            return Client.PostAsync<CreateProductRequest, CreateProductResponse>(request);
        }

        public Task<IObjectClientResponse<FindProductResponse>> FindProductAsync(int id)
        {
            return Client.GetByIdAsync<int, FindProductResponse>(id);
        }

        public Task<IObjectClientResponse<ListProductsResponse>> ListProductsAsync()
        {
            return Client.GetAsync<ListProductsResponse>();
        }

        public Task<IObjectClientResponse<RelistProductResponse>> RelistProductAsync(RelistProductRequest request)
        {
            return Client.PostAsync<RelistProductRequest, RelistProductResponse>(request);
        }

        public Task<IObjectClientResponse<UnlistProductResponse>> UnlistProductAsync(UnlistProductRequest request)
        {
            return Client.PostAsync<UnlistProductRequest, UnlistProductResponse>(request);
        }

        public Task<IObjectClientResponse<UpdateProductResponse>> UpdateProductAsync(UpdateProductRequest request)
        {
            return Client.PutByIdAsync<int, UpdateProductRequest, UpdateProductResponse>(request.Id, request);
        }
    }
}
