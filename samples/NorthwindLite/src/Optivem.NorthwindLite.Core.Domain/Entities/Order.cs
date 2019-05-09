using Optivem.Core.Domain;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class Order : IEntity<int>
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public byte StatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
