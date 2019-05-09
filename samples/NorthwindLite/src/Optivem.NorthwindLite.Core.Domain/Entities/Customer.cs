using Optivem.Core.Domain;
using System.Collections.Generic;

namespace Optivem.NorthwindLite.Core.Domain.Entities
{
    public class Customer : IEntity<int>
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<Order> Order { get; set; }
    }
}
