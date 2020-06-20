using Atomiv.Core.Domain;
using Generator.Infrastructure.EntityFrameworkCore.Orders.Records;
using System.Collections.Generic;

namespace Generator.Infrastructure.EntityFrameworkCore.Customers.Records
{
    // TODO: VC: Transfer records to EF level

    public class CustomerRecord : IIdentity<int>
    {
        public CustomerRecord()
        {
            Order = new HashSet<OrderRecord>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OrderRecord> Order { get; set; }
    }
}