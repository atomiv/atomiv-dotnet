using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class FindOrderRequest : IRequest<FindOrderResponse>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public List<FindOrderItemRequest> OrderItems { get; set; }
    }

    public class FindOrderItemRequest
    {
        public int ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}