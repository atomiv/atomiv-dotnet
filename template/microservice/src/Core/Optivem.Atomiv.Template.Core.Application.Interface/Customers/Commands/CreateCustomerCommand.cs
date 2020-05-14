using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Common.Actions;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Commands
{
    [RequestAction(ActionType.CreateCustomer)]
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}