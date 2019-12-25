using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Products.Queries
{
    public class ListProductsResponse
    {
        public List<ListProductsRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListProductsRecordResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}