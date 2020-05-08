using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public abstract class BaseRequestAuthorizer<TRequest> : IRequestAuthorizer<TRequest>
    {
        public abstract Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request);

        protected RequestAuthorizationResult Success()
        {
            return new RequestAuthorizationResult(true, new List<RequestAuthorizationError>());
        }

        protected RequestAuthorizationResult Failure(IEnumerable<RequestAuthorizationError> errors)
        {
            return new RequestAuthorizationResult(false, errors);
        }

        protected RequestAuthorizationResult Failure(string errorMessage)
        {
            var error = new RequestAuthorizationError(errorMessage);
            var errors = new List<RequestAuthorizationError> { error };

            return Failure(errors);
        }
    }
}
