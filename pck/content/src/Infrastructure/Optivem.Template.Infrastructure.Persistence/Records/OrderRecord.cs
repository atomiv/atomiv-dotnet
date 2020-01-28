using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.Persistence.Records
{
    public class OrderRecord : Record<Guid>
    {
        public OrderRecord()
        {
            OrderItems = new List<OrderItemRecord>();
        }

        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatusId { get; set; }

        public virtual CustomerRecord Customer { get; set; }
        public virtual OrderStatusRecord OrderStatus { get; set; }
        public virtual ICollection<OrderItemRecord> OrderItems { get; set; }
    }
}