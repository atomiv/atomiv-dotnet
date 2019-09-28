using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRecord : Record<int>
    {
        public OrderRecord()
        {
            OrderDetails = new List<OrderDetailRecord>();
        }

        public int CustomerId { get; set; }
        public byte StatusId { get; set; }

        public virtual CustomerRecord Customer { get; set; }
        public virtual OrderStatusRecord Status { get; set; }
        public virtual ICollection<OrderDetailRecord> OrderDetails { get; set; }
    }
}