using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Records
{
    public class CustomerRecord : Record<Guid>
    {
        public CustomerRecord()
        {
            Orders = new HashSet<OrderRecord>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OrderRecord> Orders { get; set; }
    }
}