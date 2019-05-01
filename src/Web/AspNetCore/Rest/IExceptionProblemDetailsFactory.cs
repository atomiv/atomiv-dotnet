using Microsoft.AspNetCore.Mvc;
using System;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public interface IExceptionProblemDetailsFactory<TException, TProblemDetails> : IExceptionProblemDetailsFactory
        where TException : Exception
        where TProblemDetails : ProblemDetails
    {
        TProblemDetails Create(TException exception);
    }

    public interface IExceptionProblemDetailsFactory
    {
        ProblemDetails Create(Exception exception);
    }
}
