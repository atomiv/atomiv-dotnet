using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class FindOrderResponse : IResponse<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public byte StatusId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public class OrderDetail
        {
            public int Id { get; set; }

            public int ProductId { get; set; }

            public decimal Quantity { get; set; }

            public byte StatusId { get; set; }
        }
    }
}