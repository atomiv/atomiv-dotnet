using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailStatusRecord : Record<byte>
    {
        public OrderDetailStatusRecord()
        {
            OrderDetail = new HashSet<OrderDetailRecord>();
        }

        public string Code { get; set; }

        public virtual ICollection<OrderDetailRecord> OrderDetail { get; set; }
    }
}