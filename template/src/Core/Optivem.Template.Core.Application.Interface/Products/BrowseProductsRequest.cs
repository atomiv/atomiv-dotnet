using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products
{
    public class BrowseProductsRequest : IRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}
