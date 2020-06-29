using Microsoft.AspNetCore.Mvc;
using System;

namespace Atomiv.Web.AspNetCore
{
    public abstract class BaseExceptionProblemDetailsFactory<TException, TProblemDetails>
        : IExceptionProblemDetailsFactory<TException, TProblemDetails>
        where TException : Exception
        where TProblemDetails : ProblemDetails, new()
    {
        public TProblemDetails Create(TException exception)
        {
            var title = GetTitle(exception);
            var status = GetStatus(exception);
            var detail = GetDetail(exception);
            var instance = GetInstance(exception);
            var type = GetProblemTypeUri(exception);

            return new TProblemDetails
            {
                Title = title,
                Status = status,
                Detail = detail,
                Instance = instance,
                Type = type,
            };
        }

        public ProblemDetails Create(Exception exception)
        {
            return Create((TException)exception);
        }

        protected abstract string GetTitle(TException exception);

        protected abstract string GetDetail(TException exception);

        protected abstract int GetStatus(TException exception);

        protected string GetInstance(TException exception)
        {
            return string.Empty;

            /*

            // TODO: VC: handling errors that occurred relating to some resources, could have resource/{id}/errors/{errorid}
            // TODO: VC: But no stack trace there, instead stack trace is via having special permissions, stacck trace is then extension
            // and similarly could access /api/errors/{guid}.. this is the thing from log file, but does it make sense to dereference it?

            var guid = Guid.NewGuid();

            // TODO: VC: #177: REST API - Exception Handling - Problem Details - Instance
            var instance = $"urn:atomiv:error:{guid}";

            return instance;
            */
        }

        protected abstract string GetProblemTypeUri(TException exception);
    }
}