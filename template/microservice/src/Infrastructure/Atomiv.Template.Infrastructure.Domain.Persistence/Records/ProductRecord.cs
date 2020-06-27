using Atomiv.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Records
{
    public class ProductRecord : Record<Guid>
    {
        public string ProductCode { get; set; }
        
        public string ProductName { get; set; }
        
        public decimal ListPrice { get; set; }
        
        public bool IsListed { get; set; }

        public virtual ICollection<OrderItemRecord> OrderItems { get; set; }
    }
}