using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IOrderHttpService : IHttpService
    {
        Task<IObjectClientResponse<ArchiveOrderResponse>> ArchiveOrderAsync(ArchiveOrderRequest request);

        Task<IObjectClientResponse<BrowseOrdersResponse>> BrowseOrdersAsync(BrowseOrdersRequest request);

        Task<IObjectClientResponse<CancelOrderResponse>> CancelOrderAsync(CancelOrderRequest request);

        Task<IObjectClientResponse<CreateOrderResponse>> CreateOrderAsync(CreateOrderRequest request);

        Task<IObjectClientResponse<FindOrderResponse>> FindOrderAsync(FindOrderRequest request);

        Task<IObjectClientResponse<ListOrdersResponse>> ListOrdersAsync(ListOrdersRequest request);

        Task<IObjectClientResponse<SubmitOrderResponse>> SubmitOrderAsync(SubmitOrderRequest request);

        Task<IObjectClientResponse<UpdateOrderResponse>> UpdateOrderAsync(UpdateOrderRequest request);
    }
}
