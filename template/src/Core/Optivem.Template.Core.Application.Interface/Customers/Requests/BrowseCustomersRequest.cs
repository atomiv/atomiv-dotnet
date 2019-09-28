using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class BrowseCustomersRequest : ICollectionRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}