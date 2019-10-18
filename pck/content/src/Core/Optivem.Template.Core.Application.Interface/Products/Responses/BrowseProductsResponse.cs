using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Products.Responses
{
    public class BrowseProductsResponse : ICollectionResponse<BrowseProductsRecordResponse, int>
    {
        public List<BrowseProductsRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class BrowseProductsRecordResponse
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
    }
}