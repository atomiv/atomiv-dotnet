using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        public int Id { get; set; }

        public List<UpdateOrderItemRequest> OrderItems { get; set; }
    }

    public class UpdateOrderItemRequest
    {
        public int? Id { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }
    }
}