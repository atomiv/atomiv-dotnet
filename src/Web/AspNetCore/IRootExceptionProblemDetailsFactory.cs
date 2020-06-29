using Microsoft.AspNetCore.Mvc;
using System;

namespace Atomiv.Web.AspNetCore
{
    public interface IRootExceptionProblemDetailsFactory
    {
        ProblemDetails Create(Exception exception);
    }
}
