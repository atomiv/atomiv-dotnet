using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderStatusRecord : Record<byte>
    {
        public OrderStatusRecord()
        {
            Order = new HashSet<OrderRecord>();
        }

        public string Code { get; set; }

        public virtual ICollection<OrderRecord> Order { get; set; }
    }
}