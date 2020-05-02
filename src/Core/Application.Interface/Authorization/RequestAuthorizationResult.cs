using Optivem.Atomiv.Core.Application.Interface.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Core.Application
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
