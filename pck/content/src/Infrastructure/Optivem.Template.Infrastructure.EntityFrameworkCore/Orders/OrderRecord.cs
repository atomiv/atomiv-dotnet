using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRecord : AggregateRecord<Order, int>
    {
        public OrderRecord()
        {
            OrderDetailRecords = new List<OrderDetailRecord>();
        }

        public int CustomerRecordId { get; set; }
        public byte OrderStatusRecordId { get; set; }

        public virtual CustomerRecord CustomerRecord { get; set; }
        public virtual OrderStatusRecord OrderStatusRecord { get; set; }
        public virtual ICollection<OrderDetailRecord> OrderDetailRecords { get; set; }
    }
}