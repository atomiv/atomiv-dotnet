using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Commands.Customers
{
    // TODO: VC: Examples with permissions
    // [RequestAction(RequestType.CreateCustomer)]
    public class CreateCustomerCommand : ICommand<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}