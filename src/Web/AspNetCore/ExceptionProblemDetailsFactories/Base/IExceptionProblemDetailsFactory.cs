using Microsoft.AspNetCore.Mvc;
using System;

namespace Atomiv.Web.AspNetCore
{
    public interface IExceptionProblemDetailsFactory<TException, TProblemDetails> : IExceptionProblemDetailsFactory
        where TException : Exception
        where TProblemDetails : ProblemDetails
    {
        TProblemDetails Create(TException exception);
    }

    public interface IExceptionProblemDetailsFactory
    {
        bool CanCreate(Exception exception);

        ProblemDetails Create(Exception exception);
    }
}