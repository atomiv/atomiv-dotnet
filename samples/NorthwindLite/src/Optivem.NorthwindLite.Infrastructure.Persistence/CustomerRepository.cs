using Optivem.Infrastructure.Persistence.EntityFrameworkCore;
using Optivem.NorthwindLite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Infrastructure.Persistence
{
    public class CustomerRepository : Repository<DatabaseContext, Customer, int>
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
