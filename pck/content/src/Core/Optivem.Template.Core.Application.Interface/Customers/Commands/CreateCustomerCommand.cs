using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}