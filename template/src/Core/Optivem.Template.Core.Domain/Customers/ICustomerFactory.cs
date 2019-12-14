using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerFactory
    {
        Customer Create(string firstName, string lastName);
    }
}
