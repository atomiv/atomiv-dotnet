using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailStatusRecord : Record<byte>
    {
        public OrderDetailStatusRecord()
        {
            OrderDetailRecords = new HashSet<OrderDetailRecord>();
        }

        public string Code { get; set; }

        public virtual ICollection<OrderDetailRecord> OrderDetailRecords { get; set; }
    }
}