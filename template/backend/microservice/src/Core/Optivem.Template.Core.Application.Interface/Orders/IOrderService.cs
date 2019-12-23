using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public interface IOrderService : IApplicationService
    {
        Task<OrderResponse> ArchiveOrderAsync(ArchiveOrderRequest request);

        Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request);

        Task<OrderResponse> CancelOrderAsync(CancelOrderRequest request);

        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);

        Task<FindOrderResponse> FindOrderAsync(FindOrderRequest request);

        Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request);

        Task<OrderResponse> SubmitOrderAsync(SubmitOrderRequest request);

        Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest request);
    }
}