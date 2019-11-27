using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Http
{
    public class OrderHttpService : BaseControllerClient, IOrderHttpService
    {
        public OrderHttpService(IControllerClientFactory clientFactory) 
            : base(clientFactory, "api/orders")
        {
        }

        public Task<IObjectClientResponse<ArchiveOrderResponse>> ArchiveOrderAsync(ArchiveOrderRequest request)
        {
            var id = request.Id;
            return Client.PostAsync<ArchiveOrderResponse>($"{id}/archive");
        }

        public Task<IObjectClientResponse<BrowseOrdersResponse>> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CancelOrderResponse>> CancelOrderAsync(CancelOrderRequest request)
        {
            var id = request.Id;
            return Client.PostAsync<CancelOrderResponse>($"{id}/cancel");
        }

        public Task<IObjectClientResponse<CreateOrderResponse>> CreateOrderAsync(CreateOrderRequest request)
        {
            return Client.PostAsync<CreateOrderRequest, CreateOrderResponse>(request);
        }

        public Task<IObjectClientResponse<FindOrderResponse>> FindOrderAsync(FindOrderRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<int, FindOrderResponse>(id);
        }

        public Task<IObjectClientResponse<ListOrdersResponse>> ListOrdersAsync(ListOrdersRequest request)
        {
            return Client.GetAsync<ListOrdersResponse>("list");
        }

        public Task<IObjectClientResponse<SubmitOrderResponse>> SubmitOrderAsync(SubmitOrderRequest request)
        {
            var id = request.Id;
            return Client.PostAsync<SubmitOrderResponse>($"{id}/submit");
        }

        public Task<IObjectClientResponse<UpdateOrderResponse>> UpdateOrderAsync(UpdateOrderRequest request)
        {
            return Client.PutByIdAsync<int, UpdateOrderRequest, UpdateOrderResponse>(request.Id, request);
        }
    }
}
