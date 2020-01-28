using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Orders.Responses
{
    public class CreateOrderResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
