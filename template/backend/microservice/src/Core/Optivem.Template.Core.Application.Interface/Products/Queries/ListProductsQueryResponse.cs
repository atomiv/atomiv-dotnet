using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class ListProductsQueryResponse
    {
        public List<ListProductsRecordQueryResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListProductsRecordQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}