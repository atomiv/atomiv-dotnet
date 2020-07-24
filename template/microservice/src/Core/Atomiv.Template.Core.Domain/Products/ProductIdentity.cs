using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Core.Domain.Products
{
    public class ProductIdentity : GuidIdentity
    {
        public ProductIdentity(Guid value)
            : base(value)
        {
        }
    }
}