using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRecord : Record<int>
    {
        public ProductRecord()
        {
            OrderDetail = new HashSet<OrderDetailRecord>();
        }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<OrderDetailRecord> OrderDetail { get; set; }

    }
}