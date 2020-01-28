using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using Optivem.Atomiv.Template.Web.RestClient.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient
{
    public class ProductControllerClient : IProductControllerClient
    {
        private readonly JsonHttpControllerClient _controllerClient;

        public ProductControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _controllerClient = new JsonHttpControllerClient(httpClient, jsonSerializer, "api/products");
        }

        public Task<IObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request)
        {
            return _controllerClient.GetAsync<BrowseProductsQuery, BrowseProductsQueryResponse>(request);
        }

        public Task<IObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request)
        {
            return _controllerClient.PostAsync<CreateProductCommand, CreateProductCommandResponse>(request);
        }

        public Task<IObjectClientResponse<FindProductQueryResponse>> FindProductAsync(FindProductQuery request)
        {
            var id = request.Id;
            return _controllerClient.GetByIdAsync<Guid, FindProductQueryResponse>(id);
        }

        public Task<IObjectClientResponse<ListProductsQueryResponse>> ListProductsAsync(ListProductsQuery request)
        {
            return _controllerClient.GetAsync<ListProductsQueryResponse>("list");
        }

        public Task<IObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request)
        {
            return _controllerClient.PostAsync<RelistProductCommand, RelistProductCommandResponse>(request);
        }

        public Task<IObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request)
        {
            return _controllerClient.PostAsync<UnlistProductCommand, UnlistProductCommandResponse>(request);
        }

        public Task<IObjectClientResponse<UpdateProductCommandResponse>> UpdateProductAsync(UpdateProductCommand request)
        {
            return _controllerClient.PutByIdAsync<Guid, UpdateProductCommand, UpdateProductCommandResponse>(request.Id, request);
        }
    }
}