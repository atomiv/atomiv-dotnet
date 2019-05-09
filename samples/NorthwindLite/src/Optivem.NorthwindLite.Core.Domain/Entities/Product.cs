using Optivem.Core.Domain;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class Product : IEntity<int>
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
