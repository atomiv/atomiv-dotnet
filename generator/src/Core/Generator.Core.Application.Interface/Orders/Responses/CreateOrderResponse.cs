using Atomiv.Core.Application;

namespace Generator.Core.Application.Orders.Responses
{
    public class CreateOrderResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
