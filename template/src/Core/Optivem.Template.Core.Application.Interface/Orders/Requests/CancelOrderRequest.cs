using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class CancelOrderRequest : IRequest<CancelOrderResponse, int>
    {
        public int Id { get; set; }
    }
}
