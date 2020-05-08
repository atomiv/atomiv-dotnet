using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authorization.Customers
{
    public class CreateCustomerCommandAuthorizer : BaseRequestAuthorizer<CreateCustomerCommand>
    {
        public override Task<RequestAuthorizationResult> AuthorizeAsync(CreateCustomerCommand request)
        {
            // TODO: VC: Create BaseRequestAuthorizer for returning these results

            var result = Success();
            // var result = new RequestAuthorizationResult(false, new List<RequestAuthorizationError>());

            return Task.FromResult(result);
        }
    }
}
