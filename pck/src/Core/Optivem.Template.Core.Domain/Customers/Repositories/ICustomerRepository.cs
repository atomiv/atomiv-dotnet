using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers.Entities;
using Optivem.Template.Core.Domain.Customers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Customers.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}
