using Atomiv.Core.Application;
using System.Collections.Generic;

namespace Generator.Core.Application.Orders.Responses
{
    public class ListOrdersResponse : ICollectionResponse<ListOrdersRecordResponse, int>
    {
        public List<ListOrdersRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public class ListOrdersRecordResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
