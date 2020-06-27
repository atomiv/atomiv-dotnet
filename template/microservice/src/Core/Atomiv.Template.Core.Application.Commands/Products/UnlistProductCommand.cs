using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class UnlistProductCommand : IRequest<UnlistProductCommandResponse>
    {
        public string Id { get; set; }
    }
}