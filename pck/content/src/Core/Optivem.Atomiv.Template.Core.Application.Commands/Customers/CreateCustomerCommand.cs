using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Customers
{
    // TODO: VC: Examples with permissions
    // [RequestAction(RequestType.CreateCustomer)]
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}