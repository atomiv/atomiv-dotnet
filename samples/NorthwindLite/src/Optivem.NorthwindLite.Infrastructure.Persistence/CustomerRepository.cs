using Optivem.Infrastructure.Persistence.EntityFrameworkCore;
using Optivem.NorthwindLite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Infrastructure.Persistence
{
    public class CustomerRepository : Repository<Context, Customer, int>
    {
        public CustomerRepository(Context context) : base(context)
        {
        }
    }
}
