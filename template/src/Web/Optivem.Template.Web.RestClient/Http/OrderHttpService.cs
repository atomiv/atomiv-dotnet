using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Web.RestClient.Interface;
using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<BrowseOrdersResponse>> BrowseOrdersAsync(BrowseOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CancelOrderResponse>> CancelOrderAsync(CancelOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<CreateOrderResponse>> CreateOrderAsync(CreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<FindOrderResponse>> FindOrderAsync(FindOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<ListOrdersResponse>> ListOrdersAsync(ListOrdersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<SubmitOrderResponse>> SubmitOrderAsync(SubmitOrderRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<UpdateOrderResponse>> UpdateOrderAsync(UpdateOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
