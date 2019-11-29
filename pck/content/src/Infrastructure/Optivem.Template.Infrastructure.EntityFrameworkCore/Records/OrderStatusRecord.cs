using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Common.Orders;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Records
{
    public class OrderStatusRecord : Record<OrderStatus>
    {
        public OrderStatusRecord()
        {
            OrderRecords = new HashSet<OrderRecord>();
        }

        public string Code { get; set; }

        public virtual ICollection<OrderRecord> OrderRecords { get; set; }
    }
}