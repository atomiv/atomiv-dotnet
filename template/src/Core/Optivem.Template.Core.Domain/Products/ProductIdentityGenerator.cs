using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductIdentityGenerator : IIdentityGenerator<ProductIdentity>
    {
        public ProductIdentity Next()
        {
            return new ProductIdentity(Guid.NewGuid());
        }
    }
}
