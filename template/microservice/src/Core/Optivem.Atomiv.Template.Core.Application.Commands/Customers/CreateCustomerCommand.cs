using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Common.Actions;

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