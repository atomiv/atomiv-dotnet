using Atomiv.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Records
{
    public class CustomerRecord : Record<Guid>
    {
        public string ReferenceNumber { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public virtual ICollection<OrderRecord> Orders { get; set; }
    }
}