using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Core.Common.Orders;
using System.Collections.Generic;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Records
{
    public class OrderStatusRecord : Record<OrderStatus>
    {
        public string Code { get; set; }

        public virtual ICollection<OrderRecord> OrderRecords { get; set; }
    }
}