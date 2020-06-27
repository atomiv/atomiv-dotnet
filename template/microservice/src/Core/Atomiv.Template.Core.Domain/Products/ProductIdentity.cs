using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Products
{
    public class ProductIdentity : Identity<string>
    {
        public ProductIdentity(string value)
            : base(value)
        {
        }
    }
}