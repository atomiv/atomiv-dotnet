using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Records
{
    public class OrderItemRecord : Record<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public byte OrderItemStatusId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual OrderRecord Order { get; set; }
        public virtual ProductRecord Product { get; set; }
        public virtual OrderItemStatusRecord OrderItemStatus { get; set; }
    }
}