using Atomiv.Core.Application;
using System.Collections.Generic;

namespace Generator.Core.Application.Products.Responses
{
    public class BrowseProductsResponse : ICollectionResponse<BrowseProductsRecordResponse, int>
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
