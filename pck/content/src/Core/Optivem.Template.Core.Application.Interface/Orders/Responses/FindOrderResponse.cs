using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class FindOrderResponse
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public byte StatusId { get; set; }

        public List<FindOrderItemResponse> OrderItems { get; set; }
    }

    public class FindOrderItemResponse
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public byte StatusId { get; set; }
    }
}