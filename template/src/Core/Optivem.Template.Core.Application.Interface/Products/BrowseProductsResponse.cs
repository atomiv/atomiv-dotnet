using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products
{
    public class BrowseProductsResponse : ICollectionResponse<BrowseProductsRecordResponse>
    {
        public List<BrowseProductsRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public class BrowseProductsRecordResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
