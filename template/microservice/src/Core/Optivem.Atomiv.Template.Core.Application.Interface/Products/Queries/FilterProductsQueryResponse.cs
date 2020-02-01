using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Template.Core.Application.Products.Queries
{
    public class FilterProductsQueryResponse
    {
        public List<ListProductsRecordQueryResponse> Records { get; set; }

        public long TotalRecords { get; set; }
    }

    public class ListProductsRecordQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}