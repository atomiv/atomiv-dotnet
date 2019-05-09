using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class OrderDetailStatus : IEntity<byte>
    {
        public OrderDetailStatus()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public byte Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
