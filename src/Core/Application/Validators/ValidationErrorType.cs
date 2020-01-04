using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application.Validators
{
    public enum ValidationErrorType
    {
        None = 0,
        NotFound = 404,
        UnprocessableEntity = 422,
    }
}
