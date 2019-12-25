using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public interface IOrderApplicationService : IApplicationService
    {
        Task<OrderResponse> ArchiveOrderAsync(Guid id);

        Task<BrowseOrdersResponse> BrowseOrdersAsync(BrowseOrdersRequest request);

        Task<OrderResponse> CancelOrderAsync(Guid id);

        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);

        Task<FindOrderResponse> FindOrderAsync(Guid id);

        Task<ListOrdersResponse> ListOrdersAsync(ListOrdersRequest request);

        Task<OrderResponse> SubmitOrderAsync(Guid id);

        Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest request);
    }
}