using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public interface IOrderApplicationService : IApplicationService
    {
        Task<ArchiveOrderCommandResponse> ArchiveOrderAsync(ArchiveOrderCommand request);

        Task<BrowseOrdersQueryResponse> BrowseOrdersAsync(BrowseOrdersQuery request);

        Task<CancelOrderCommandResponse> CancelOrderAsync(CancelOrderCommand request);

        Task<CreateOrderCommandResponse> CreateOrderAsync(CreateOrderCommand request);

        Task<FindOrderQueryResponse> FindOrderAsync(FindOrderQuery request);

        Task<ListOrdersQueryResponse> ListOrdersAsync(ListOrdersQuery request);

        Task<SubmitOrderCommandResponse> SubmitOrderAsync(SubmitOrderCommand request);

        Task<UpdateOrderCommandResponse> UpdateOrderAsync(UpdateOrderCommand request);
    }
}