using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class CancelOrderRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
