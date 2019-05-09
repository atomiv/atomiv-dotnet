using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class OrderStatus : IEntity<byte>
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        public byte Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
