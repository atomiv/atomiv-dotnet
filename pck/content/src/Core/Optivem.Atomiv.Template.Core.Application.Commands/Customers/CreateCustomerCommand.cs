using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Common.Actions;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Customers
{
    [RequestAction(RequestType.CreateCustomer)]
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}