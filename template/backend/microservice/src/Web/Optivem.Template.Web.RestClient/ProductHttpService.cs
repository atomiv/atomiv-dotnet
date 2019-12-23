using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient
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

        public Task<IObjectClientResponse<ProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            return Client.PostAsync<CreateProductRequest, ProductResponse>(request);
        }

        public Task<IObjectClientResponse<FindProductResponse>> FindProductAsync(FindProductRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<Guid, FindProductResponse>(id);
        }

        public Task<IObjectClientResponse<ListProductsResponse>> ListProductsAsync(ListProductRequest request)
        {
            return Client.GetAsync<ListProductsResponse>("list");
        }

        public Task<IObjectClientResponse<ProductResponse>> RelistProductAsync(RelistProductRequest request)
        {
            return Client.PostAsync<RelistProductRequest, ProductResponse>(request);
        }

        public Task<IObjectClientResponse<ProductResponse>> UnlistProductAsync(UnlistProductRequest request)
        {
            return Client.PostAsync<UnlistProductRequest, ProductResponse>(request);
        }

        public Task<IObjectClientResponse<ProductResponse>> UpdateProductAsync(UpdateProductRequest request)
        {
            return Client.PutByIdAsync<Guid, UpdateProductRequest, ProductResponse>(request.Id, request);
        }
    }
}