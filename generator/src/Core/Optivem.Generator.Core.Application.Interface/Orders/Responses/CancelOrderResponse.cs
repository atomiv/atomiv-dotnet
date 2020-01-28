using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Orders.Responses
{
    public class CancelOrderResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
