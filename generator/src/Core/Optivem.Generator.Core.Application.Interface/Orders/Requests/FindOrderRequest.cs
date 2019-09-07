using Optivem.Framework.Core.Application;

namespace Optivem.Generator.Core.Application.Orders.Requests
{
    public class FindOrderRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
