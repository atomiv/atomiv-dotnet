using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class CancelOrderResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
