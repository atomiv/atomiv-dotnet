using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class CreateOrderResponse : IResponse<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int StatusId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public class OrderDetail
        {
            public int Id { get; set; }

            public int ProductId { get; set; }

            public decimal Quantity { get; set; }

            public int StatusId { get; set; }
        }
    }
}
