using Atomiv.Core.Application;

namespace Generator.Core.Application.Orders.Requests
{
    public class FindOrderRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
