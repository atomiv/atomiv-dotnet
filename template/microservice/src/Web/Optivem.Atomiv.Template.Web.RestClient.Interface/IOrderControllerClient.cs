using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient.Interface
{
    public interface IOrderControllerClient : IHttpControllerClient
    {
        #region Commands

        Task<ObjectClientResponse<ArchiveOrderCommandResponse>> ArchiveOrderAsync(ArchiveOrderCommand request);

        Task<ObjectClientResponse<CancelOrderCommandResponse>> CancelOrderAsync(CancelOrderCommand request);

        Task<ObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request);

        Task<ObjectClientResponse<EditOrderCommandResponse>> EditOrderAsync(EditOrderCommand request);

        Task<ObjectClientResponse<SubmitOrderCommandResponse>> SubmitOrderAsync(SubmitOrderCommand request);

        #endregion

        #region Queries

        Task<ObjectClientResponse<BrowseOrdersQueryResponse>> BrowseOrdersAsync(BrowseOrdersQuery request);

        Task<ObjectClientResponse<FilterOrdersQueryResponse>> FilterOrdersAsync(FilterOrdersQuery request);

        Task<ObjectClientResponse<ViewOrderQueryResponse>> ViewOrderAsync(ViewOrderQuery request);

        #endregion
    }
}
