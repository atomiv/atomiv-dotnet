using Optivem.Core.Domain;
using System.Collections.Generic;

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