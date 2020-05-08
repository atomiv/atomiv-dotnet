using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using Optivem.Atomiv.Template.Web.RestClient.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient
{
    public class OrderControllerClient : IOrderControllerClient
    {
        private readonly JsonHttpControllerClient _controllerClient;

        public OrderControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            _controllerClient = new JsonHttpControllerClient(httpClient, jsonSerializer, "api/orders");
        }

        #region Commands

        public Task<ObjectClientResponse<ArchiveOrderCommandResponse>> ArchiveOrderAsync(ArchiveOrderCommand request)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<ArchiveOrderCommandResponse>($"{id}/archive");
        }

        public Task<ObjectClientResponse<CancelOrderCommandResponse>> CancelOrderAsync(CancelOrderCommand request)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<CancelOrderCommandResponse>($"{id}/cancel");
        }

        public Task<ObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request)
        {
            return _controllerClient.PostAsync<CreateOrderCommand, CreateOrderCommandResponse>(request);
        }

        public Task<ObjectClientResponse<EditOrderCommandResponse>> EditOrderAsync(EditOrderCommand request)
        {
            return _controllerClient.PutByIdAsync<Guid, EditOrderCommand, EditOrderCommandResponse>(request.Id, request);
        }

        public Task<ObjectClientResponse<SubmitOrderCommandResponse>> SubmitOrderAsync(SubmitOrderCommand request)
        {
            var id = request.Id;
            return _controllerClient.PostAsync<SubmitOrderCommandResponse>($"{id}/submit");
        }

        #endregion

        #region Queries

        public Task<ObjectClientResponse<BrowseOrdersQueryResponse>> BrowseOrdersAsync(BrowseOrdersQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<ObjectClientResponse<FilterOrdersQueryResponse>> FilterOrdersAsync(FilterOrdersQuery request)
        {
            return _controllerClient.GetAsync<FilterOrdersQueryResponse>("filter");
        }

        public Task<ObjectClientResponse<ViewOrderQueryResponse>> ViewOrderAsync(ViewOrderQuery request)
        {
            var id = request.Id;
            return _controllerClient.GetByIdAsync<Guid, ViewOrderQueryResponse>(id);
        }

        #endregion
    }
}
