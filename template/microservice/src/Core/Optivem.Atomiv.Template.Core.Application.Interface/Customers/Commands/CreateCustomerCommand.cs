using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}