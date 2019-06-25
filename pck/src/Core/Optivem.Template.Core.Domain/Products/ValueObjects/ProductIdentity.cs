using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Products.ValueObjects
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id)
            : base(id)
        {
        }
    }
}
