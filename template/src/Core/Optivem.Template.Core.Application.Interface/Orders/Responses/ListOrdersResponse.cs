using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Responses
{
    public class ListOrdersResponse : ICollectionResponse<ListOrdersRecordResponse, int>
    {
        public List<ListOrdersRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListOrdersRecordResponse
    {
        public int Id { get; set; }
    }
}
