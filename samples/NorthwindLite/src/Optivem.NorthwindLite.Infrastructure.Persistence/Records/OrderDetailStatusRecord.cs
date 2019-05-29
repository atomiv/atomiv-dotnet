using Optivem.Core.Domain;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Infrastructure.Persistence.Records
{
    public class OrderDetailStatusRecord
    {
        public OrderDetailStatusRecord()
        {
            OrderDetail = new HashSet<OrderDetailRecord>();
        }

        public byte Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<OrderDetailRecord> OrderDetail { get; set; }
    }
}