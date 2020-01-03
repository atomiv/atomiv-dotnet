using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Queries;
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

        public Task<IObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request)
        {
            return Client.GetAsync<BrowseProductsQuery, BrowseProductsQueryResponse>(request);
        }

        public Task<IObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request)
        {
            return Client.PostAsync<CreateProductCommand, CreateProductCommandResponse>(request);
        }

        public Task<IObjectClientResponse<FindProductQueryResponse>> FindProductAsync(FindProductQuery request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<Guid, FindProductQueryResponse>(id);
        }

        public Task<IObjectClientResponse<ListProductsQueryResponse>> ListProductsAsync(ListProductsQuery request)
        {
            return Client.GetAsync<ListProductsQueryResponse>("list");
        }

        public Task<IObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request)
        {
            return Client.PostAsync<RelistProductCommand, RelistProductCommandResponse>(request);
        }

        public Task<IObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request)
        {
            return Client.PostAsync<UnlistProductCommand, UnlistProductCommandResponse>(request);
        }

        public Task<IObjectClientResponse<UpdateProductCommandResponse>> UpdateProductAsync(UpdateProductCommand request)
        {
            return Client.PutByIdAsync<Guid, UpdateProductCommand, UpdateProductCommandResponse>(request.Id, request);
        }
    }
}