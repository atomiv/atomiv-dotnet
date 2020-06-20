using System.Collections.Generic;

namespace Atomiv.Core.Application
{
    public class RequestAuthorizationResult
    {
        public RequestAuthorizationResult(bool isAuthorized, IEnumerable<RequestAuthorizationError> errors)
        {
            IsAuthorized = isAuthorized;
            Errors = errors;
        }

        public bool IsAuthorized { get; }

        public IEnumerable<RequestAuthorizationError> Errors { get; }
    }
}
