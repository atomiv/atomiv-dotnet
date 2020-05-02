using Optivem.Atomiv.Core.Application;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.System
{
    // TODO: VC: Check

    public class RoleAuthorizer<TRequest> : IRequestAuthorizer<TRequest>
    {
        public Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
