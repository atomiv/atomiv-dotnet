using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient
{
    public class OrderControllerClient : IOrderControllerClient
    {
        private readonly JsonHttpControllerClient _controllerClient;

        public OrderControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _controllerClient = new JsonHttpControllerClient(httpClient, jsonSerializer, "api/orders");
        }

        public Task<IObjectClientResponse<ArchiveOrderCommandResponse>> ArchiveOrderAsync(ArchiveOrderCommand request)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<ArchiveOrderCommandResponse>($"{id}/archive");
        }

        public Task<IObjectClientResponse<BrowseOrdersQueryResponse>> BrowseOrdersAsync(BrowseOrdersQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CancelOrderCommandResponse>> CancelOrderAsync(CancelOrderCommand request)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<CancelOrderCommandResponse>($"{id}/cancel");
        }

        public Task<IObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request)
        {
            return _controllerClient.PostAsync<CreateOrderCommand, CreateOrderCommandResponse>(request);
        }

        public Task<IObjectClientResponse<FindOrderQueryResponse>> FindOrderAsync(FindOrderQuery request)
        {
            var id = request.Id;
            return _controllerClient.GetByIdAsync<Guid, FindOrderQueryResponse>(id);
        }

        public Task<IObjectClientResponse<ListOrdersQueryResponse>> ListOrdersAsync(ListOrdersQuery request)
        {
            return _controllerClient.GetAsync<ListOrdersQueryResponse>("list");
        }

        public Task<IObjectClientResponse<SubmitOrderCommandResponse>> SubmitOrderAsync(SubmitOrderCommand request)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<SubmitOrderCommandResponse>($"{id}/submit");
        }

        public Task<IObjectClientResponse<UpdateOrderCommandResponse>> UpdateOrderAsync(UpdateOrderCommand request)
        {
            return _controllerClient.PutByIdAsync<Guid, UpdateOrderCommand, UpdateOrderCommandResponse>(request.Id, request);
        }
    }
}
