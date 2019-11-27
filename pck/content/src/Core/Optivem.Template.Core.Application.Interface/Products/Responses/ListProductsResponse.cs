using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Products.Responses
{
    public class ListProductsResponse
    {
        public List<ListProductsRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class ListProductsRecordResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}