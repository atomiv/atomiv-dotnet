using Optivem.Framework.Core.Common;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class SubmitOrderResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
