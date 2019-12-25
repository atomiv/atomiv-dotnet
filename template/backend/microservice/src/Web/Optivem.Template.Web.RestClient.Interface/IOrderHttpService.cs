using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IOrderHttpService : IHttpService
    {
        Task<IObjectClientResponse<OrderResponse>> ArchiveOrderAsync(ArchiveOrderRequest request);

        Task<IObjectClientResponse<BrowseOrdersResponse>> BrowseOrdersAsync(BrowseOrdersRequest request);

        Task<IObjectClientResponse<OrderResponse>> CancelOrderAsync(CancelOrderRequest request);

        Task<IObjectClientResponse<OrderResponse>> CreateOrderAsync(CreateOrderRequest request);

        Task<IObjectClientResponse<FindOrderResponse>> FindOrderAsync(FindOrderRequest request);

        Task<IObjectClientResponse<ListOrdersResponse>> ListOrdersAsync(ListOrdersRequest request);

        Task<IObjectClientResponse<OrderResponse>> SubmitOrderAsync(SubmitOrderRequest request);

        Task<IObjectClientResponse<OrderResponse>> UpdateOrderAsync(UpdateOrderRequest request);
    }
}
