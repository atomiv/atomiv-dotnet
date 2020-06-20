using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Products
{
    public class ProductIdentity : Identity<Guid>
    {
        public ProductIdentity(Guid value)
            : base(value)
        {
        }
    }
}