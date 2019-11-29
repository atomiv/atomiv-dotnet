using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Common.Orders;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Records
{
    public class OrderItemStatusRecord : Record<OrderItemStatus>
    {
        public OrderItemStatusRecord()
        {
            OrderItems = new HashSet<OrderItemRecord>();
        }

        public string Code { get; set; }

        public virtual ICollection<OrderItemRecord> OrderItems { get; set; }
    }
}