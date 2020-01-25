using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Queries;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IOrderControllerClient : IHttpControllerClient
    {
        Task<IObjectClientResponse<ArchiveOrderCommandResponse>> ArchiveOrderAsync(ArchiveOrderCommand request);

        Task<IObjectClientResponse<BrowseOrdersQueryResponse>> BrowseOrdersAsync(BrowseOrdersQuery request);

        Task<IObjectClientResponse<CancelOrderCommandResponse>> CancelOrderAsync(CancelOrderCommand request);

        Task<IObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request);

        Task<IObjectClientResponse<FindOrderQueryResponse>> FindOrderAsync(FindOrderQuery request);

        Task<IObjectClientResponse<ListOrdersQueryResponse>> ListOrdersAsync(ListOrdersQuery request);

        Task<IObjectClientResponse<SubmitOrderCommandResponse>> SubmitOrderAsync(SubmitOrderCommand request);

        Task<IObjectClientResponse<UpdateOrderCommandResponse>> UpdateOrderAsync(UpdateOrderCommand request);
    }
}
