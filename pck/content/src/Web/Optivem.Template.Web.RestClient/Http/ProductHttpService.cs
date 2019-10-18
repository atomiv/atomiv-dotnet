using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Web.RestClient.Interface;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Http
{
    public class ProductHttpService : BaseControllerClient, IProductHttpService
    {
        public ProductHttpService(IControllerClientFactory clientFactory)
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

        public Task<IObjectClientResponse<FindProductResponse>> FindProductAsync(FindProductRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<int, FindProductResponse>(id);
        }

        public Task<IObjectClientResponse<ListProductsResponse>> ListProductsAsync(ListProductsRequest request)
        {
            return Client.GetAsync<ListProductsResponse>("list");
        }

        public Task<IObjectClientResponse<ActivateProductResponse>> RelistProductAsync(ActivateProductRequest request)
        {
            return Client.PostAsync<ActivateProductRequest, ActivateProductResponse>(request);
        }

        public Task<IObjectClientResponse<DeactivateProductResponse>> UnlistProductAsync(DeactivateProductRequest request)
        {
            return Client.PostAsync<DeactivateProductRequest, DeactivateProductResponse>(request);
        }

        public Task<IObjectClientResponse<UpdateProductResponse>> UpdateProductAsync(UpdateProductRequest request)
        {
            return Client.PutByIdAsync<int, UpdateProductRequest, UpdateProductResponse>(request.Id, request);
        }
    }
}