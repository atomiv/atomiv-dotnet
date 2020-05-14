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

        #region Commands

        public Task<ObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request, HeaderData header)
        {
            return _controllerClient.PostAsync<CreateProductCommand, CreateProductCommandResponse>(request);
        }

        public Task<ObjectClientResponse<EditProductCommandResponse>> EditProductAsync(EditProductCommand request, HeaderData header)
        {
            return _controllerClient.PutByIdAsync<Guid, EditProductCommand, EditProductCommandResponse>(request.Id, request);
        }

        public Task<ObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request, HeaderData header)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<RelistProductCommand, RelistProductCommandResponse>($"{id}/relist", request);
        }

        public Task<ObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request, HeaderData header)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<UnlistProductCommand, UnlistProductCommandResponse>($"{id}/unlist", request);
        }

        #endregion

        #region Queries

        public Task<ObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request, HeaderData header)
        {
            return _controllerClient.GetAsync<BrowseProductsQuery, BrowseProductsQueryResponse>(request);
        }

        public Task<ObjectClientResponse<FilterProductsQueryResponse>> FilterProductsAsync(FilterProductsQuery request, HeaderData header)
        {
            return _controllerClient.GetAsync<FilterProductsQueryResponse>("filter");
        }

        public Task<ObjectClientResponse<ViewProductQueryResponse>> ViewProductAsync(ViewProductQuery request, HeaderData header)
        {
            var id = request.Id;
            return _controllerClient.GetByIdAsync<Guid, ViewProductQueryResponse>(id);
        }

        #endregion
    }
}