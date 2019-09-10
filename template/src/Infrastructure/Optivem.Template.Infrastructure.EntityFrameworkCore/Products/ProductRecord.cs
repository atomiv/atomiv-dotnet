using Optivem.Framework.Core.Domain;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRecord : IIdentity<int>
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