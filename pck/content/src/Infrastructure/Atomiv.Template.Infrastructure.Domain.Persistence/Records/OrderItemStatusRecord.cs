using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Core.Common.Orders;
using System.Collections.Generic;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Records
{
    public class OrderItemStatusRecord : Record<OrderItemStatus>
    {
        public string Code { get; set; }

        public virtual ICollection<OrderItemRecord> OrderItems { get; set; }
    }
}