using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Queries.Products
{
    public class FilterProductsQueryResponse
    {
        public List<ListProductsRecordQueryResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class ListProductsRecordQueryResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}