using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Core.Common.Orders;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records
{
    public class OrderItemRecord : Record<Guid>
    {
        public Guid ProductId { get; set; }

        public OrderItemStatus StatusId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
