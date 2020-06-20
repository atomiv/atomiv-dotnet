using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}