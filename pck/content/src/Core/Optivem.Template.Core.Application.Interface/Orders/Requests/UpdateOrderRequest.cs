using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse, int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public class OrderDetail
        {
            public int? Id { get; set; }

            public int ProductId { get; set; }

            public decimal Quantity { get; set; }
        }
    }
}