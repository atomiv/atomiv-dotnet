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

        public Task<IObjectClientResponse<ArchiveOrderCommandResponse>> ArchiveOrderAsync(ArchiveOrderCommand request)
        {
            var id = request.Id;
            return Client.PostAsync<ArchiveOrderCommandResponse>($"{id}/archive");
        }

        public Task<IObjectClientResponse<BrowseOrdersQueryResponse>> BrowseOrdersAsync(BrowseOrdersQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CancelOrderCommandResponse>> CancelOrderAsync(CancelOrderCommand request)
        {
            var id = request.Id;
            return Client.PostAsync<CancelOrderCommandResponse>($"{id}/cancel");
        }

        public Task<IObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request)
        {
            return Client.PostAsync<CreateOrderCommand, CreateOrderCommandResponse>(request);
        }

        public Task<IObjectClientResponse<FindOrderQueryResponse>> FindOrderAsync(FindOrderQuery request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<Guid, FindOrderQueryResponse>(id);
        }

        public Task<IObjectClientResponse<ListOrdersQueryResponse>> ListOrdersAsync(ListOrdersQuery request)
        {
            return Client.GetAsync<ListOrdersQueryResponse>("list");
        }

        public Task<IObjectClientResponse<SubmitOrderCommandResponse>> SubmitOrderAsync(SubmitOrderCommand request)
        {
            var id = request.Id;
            return Client.PostAsync<SubmitOrderCommandResponse>($"{id}/submit");
        }

        public Task<IObjectClientResponse<UpdateOrderCommandResponse>> UpdateOrderAsync(UpdateOrderCommand request)
        {
            return Client.PutByIdAsync<Guid, UpdateOrderCommand, UpdateOrderCommandResponse>(request.Id, request);
        }
    }
}
