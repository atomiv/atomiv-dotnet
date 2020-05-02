using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Core.Application.Interface.Authorization
{
    public class RequestAuthorizationError
    {
        public RequestAuthorizationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
    }
}
