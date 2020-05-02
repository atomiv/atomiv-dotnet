using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public interface IRequestAuthorizer<TRequest>
    {
        Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request);
    }
}
