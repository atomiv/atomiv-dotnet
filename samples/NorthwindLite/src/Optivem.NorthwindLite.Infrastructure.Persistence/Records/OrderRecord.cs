using Optivem.Core.Domain;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Infrastructure.Persistence.Records
{
    public class OrderRecord
    {
        public OrderRecord()
        {
            OrderDetail = new HashSet<OrderDetailRecord>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public byte StatusId { get; set; }

        public virtual CustomerRecord Customer { get; set; }
        public virtual OrderStatusRecord Status { get; set; }
        public virtual ICollection<OrderDetailRecord> OrderDetail { get; set; }
    }
}