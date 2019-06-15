using Optivem.Core.Domain;
using Optivem.NorthwindLite.Infrastructure.EntityFrameworkCore.Orders;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Infrastructure.EntityFrameworkCore.Customers
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