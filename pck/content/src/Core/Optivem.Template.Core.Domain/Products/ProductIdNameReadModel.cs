using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductIdNameReadModel : IdNameReadModel<int>
    {
        public ProductIdNameReadModel(int id, string name) : base(id, name)
        {
        }
    }
}
