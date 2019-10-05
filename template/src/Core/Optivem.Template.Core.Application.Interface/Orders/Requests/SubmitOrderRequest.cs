using Optivem.Framework.Core.Common;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class SubmitOrderRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
