using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public interface IOrderService : IApplicationService
    {
        Task<ArchiveOrderResponse> ArchiveOrderAsync(ArchiveOrderRequest request);

        Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request);

        Task<CancelOrderResponse> CancelOrderAsync(CancelOrderRequest request);

        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);

        Task<FindOrderResponse> FindOrderAsync(FindOrderRequest request);

        Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request);

        Task<SubmitOrderResponse> SubmitOrderAsync(SubmitOrderRequest request);

        Task<UpdateOrderResponse> UpdateOrderAsync(UpdateOrderRequest request);
    }
}