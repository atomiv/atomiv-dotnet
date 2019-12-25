using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class BrowseCustomersRequest : IRequest<BrowseCustomersResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}