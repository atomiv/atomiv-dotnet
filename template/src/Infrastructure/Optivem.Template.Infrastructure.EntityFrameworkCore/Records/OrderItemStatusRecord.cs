using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Records
{
    public class OrderItemStatusRecord : Record<byte>
    {
        public OrderItemStatusRecord()
        {
            OrderItems = new HashSet<OrderItemRecord>();
        }

        public string Code { get; set; }

        public virtual ICollection<OrderItemRecord> OrderItems { get; set; }
    }
}