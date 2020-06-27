using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Commands.Orders
{
    public class SubmitOrderCommand : IRequest<SubmitOrderCommandResponse>
    {
        public string Id { get; set; }
    }
}