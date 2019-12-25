using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient
{
    public class OrderHttpService : BaseControllerClient, IOrderHttpService
    {
        public OrderHttpService(IControllerClientFactory clientFactory) 
            : base(clientFactory, "api/orders")
        {
        }

        public Task<IObjectClientResponse<OrderResponse>> ArchiveOrderAsync(ArchiveOrderRequest request)
        {
            var id = request.Id;
            return Client.PostAsync<OrderResponse>($"{id}/archive");
        }

        public Task<IObjectClientResponse<BrowseOrdersResponse>> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<OrderResponse>> CancelOrderAsync(CancelOrderRequest request)
        {
            var id = request.Id;
            return Client.PostAsync<OrderResponse>($"{id}/cancel");
        }

        public Task<IObjectClientResponse<OrderResponse>> CreateOrderAsync(CreateOrderRequest request)
        {
            return Client.PostAsync<CreateOrderRequest, OrderResponse>(request);
        }

        public Task<IObjectClientResponse<FindOrderResponse>> FindOrderAsync(FindOrderRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<Guid, FindOrderResponse>(id);
        }

        public Task<IObjectClientResponse<ListOrdersResponse>> ListOrdersAsync(ListOrdersRequest request)
        {
            return Client.GetAsync<ListOrdersResponse>("list");
        }

        public Task<IObjectClientResponse<OrderResponse>> SubmitOrderAsync(SubmitOrderRequest request)
        {
            var id = request.Id;
            return Client.PostAsync<OrderResponse>($"{id}/submit");
        }

        public Task<IObjectClientResponse<OrderResponse>> UpdateOrderAsync(UpdateOrderRequest request)
        {
            return Client.PutByIdAsync<Guid, UpdateOrderRequest, OrderResponse>(request.Id, request);
        }
    }
}
