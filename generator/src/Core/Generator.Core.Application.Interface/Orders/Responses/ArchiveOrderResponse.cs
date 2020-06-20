using Atomiv.Core.Application;

namespace Generator.Core.Application.Orders.Responses
{
    public class ArchiveOrderResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
