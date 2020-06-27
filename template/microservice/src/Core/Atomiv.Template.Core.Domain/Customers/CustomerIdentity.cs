using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<string>
    {
        public CustomerIdentity(string value) : base(value)
        {
        }
    }
}