using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class BrowseOrdersResponse : ICollectionResponse<BrowseOrdersRecordResponse, int>
    {
        public List<BrowseOrdersRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class BrowseOrdersRecordResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
