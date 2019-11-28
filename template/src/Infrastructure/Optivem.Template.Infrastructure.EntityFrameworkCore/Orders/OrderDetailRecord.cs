using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using System;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailRecord : Record<Guid>
    {
        public Guid OrderRecordId { get; set; }
        public Guid ProductRecordId { get; set; }
        public byte OrderDetailStatusRecordId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual OrderRecord OrderRecord { get; set; }
        public virtual ProductRecord ProductRecord { get; set; }
        public virtual OrderDetailStatusRecord OrderDetailStatusRecord { get; set; }
    }
}