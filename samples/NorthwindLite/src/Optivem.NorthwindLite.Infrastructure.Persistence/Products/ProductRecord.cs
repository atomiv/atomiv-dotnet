using Optivem.NorthwindLite.Infrastructure.EntityFrameworkCore.Orders;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRecord
    {
        public ProductRecord()
        {
            OrderDetail = new HashSet<OrderDetailRecord>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }

        public virtual ICollection<OrderDetailRecord> OrderDetail { get; set; }
    }
}