using System.Collections.Generic;

namespace Optivem.NorthwindLite.Infrastructure.Persistence.Records
{
    public class OrderStatusRecord
    {
        public OrderStatusRecord()
        {
            Order = new HashSet<OrderRecord>();
        }

        public byte Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<OrderRecord> Order { get; set; }
    }
}