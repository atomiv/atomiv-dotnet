using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Domain.Identities
{
    public class ProductIdentity : Identity<int>
    {
        public ProductIdentity(int id) 
            : base(id)
        {
        }
    }
}
