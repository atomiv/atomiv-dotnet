using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerCommandResponse>
    {
        public string Id { get; set; }
    }
}