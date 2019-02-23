using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public interface IProblemDetailsFactory<TException, TProblemDetails> : IProblemDetailsFactory
        where TException : Exception
        where TProblemDetails : ProblemDetails
    {
        TProblemDetails Create(TException exception);
    }

    public interface IProblemDetailsFactory
    {
        ProblemDetails Create(Exception exception);
    }
}
