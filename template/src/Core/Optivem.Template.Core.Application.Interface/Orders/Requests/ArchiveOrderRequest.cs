using Optivem.Core.Application;

namespace Optivem.Template.Core.Application.Orders
{
    public class ArchiveOrderRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
