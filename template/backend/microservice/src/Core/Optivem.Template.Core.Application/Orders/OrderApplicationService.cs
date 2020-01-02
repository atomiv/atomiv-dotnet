using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders
{
    public class OrderApplicationService : ApplicationService, IOrderApplicationService
    {
        public OrderApplicationService(IRequestHandler requestHandler) : base(requestHandler)
        {
        }

        public Task<ArchiveOrderCommandResponse> ArchiveOrderAsync(ArchiveOrderCommand request)
        {
            return HandleAsync(request);
        }

        public Task<BrowseOrdersQueryResponse> BrowseOrdersAsync(BrowseOrdersQuery request)
        {
            return HandleAsync(request);
        }

        public Task<CancelOrderCommandResponse> CancelOrderAsync(CancelOrderCommand request)
        {
            return HandleAsync(request);
        }

        public Task<CreateOrderCommandResponse> CreateOrderAsync(CreateOrderCommand request)
        {
            return HandleAsync(request);
        }

        public Task<FindOrderQueryResponse> FindOrderAsync(FindOrderQuery request)
        {
            return HandleAsync(request);
        }

        public Task<ListOrdersQueryResponse> ListOrdersAsync(ListOrdersQuery request)
        {
            return HandleAsync(request);
        }

        public Task<SubmitOrderCommandResponse> SubmitOrderAsync(SubmitOrderCommand request)
        {
            return HandleAsync(request);
        }

        public Task<UpdateOrderCommandResponse> UpdateOrderAsync(UpdateOrderCommand request)
        {
            return HandleAsync(request);
        }
    }
}