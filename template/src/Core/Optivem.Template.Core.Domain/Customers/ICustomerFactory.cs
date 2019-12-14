using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerFactory : IFactory
    {
        Customer Create(string firstName, string lastName);
    }
}
