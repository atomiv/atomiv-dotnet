using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
