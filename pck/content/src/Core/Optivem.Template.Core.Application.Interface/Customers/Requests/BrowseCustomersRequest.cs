using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Customers.Responses;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class BrowseCustomersRequest : IRequest<BrowseCustomersResponse>
    {
        public int Page { get; set; }

        public int Size { get; set; }
    }
}