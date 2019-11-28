using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using System;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailRecord : Record<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public byte OrderDetailStatusId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual OrderRecord Order { get; set; }
        public virtual ProductRecord Product { get; set; }
        public virtual OrderDetailStatusRecord OrderDetailStatus { get; set; }
    }
}