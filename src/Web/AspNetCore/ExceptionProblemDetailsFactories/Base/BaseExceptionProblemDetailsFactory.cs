using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Atomiv.Web.AspNetCore
{
    public abstract class BaseExceptionProblemDetailsFactory<TException, TProblemDetails>
        : IExceptionProblemDetailsFactory<TException, TProblemDetails>
        where TException : Exception
        where TProblemDetails : ProblemDetails, new()
    {

        private readonly HttpStatusCode _statusCode;
        private readonly string _problemTypeUri;

        public BaseExceptionProblemDetailsFactory(HttpStatusCode statusCode, string problemTypeUri)
        {
            _statusCode = statusCode;
            _problemTypeUri = problemTypeUri;
        }

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

        public bool CanCreate(Exception exception)
        {
            var specificException = exception as TException;
            return specificException != null;
        }

        public ProblemDetails Create(Exception exception)
        {
            var specificException = exception as TException;
            return Create(specificException);
        }

        protected virtual string GetTitle(TException exception)
        {
            return _statusCode.ToString();
        }

        protected virtual string GetDetail(TException exception)
        {
            return exception.Message;
        }

        protected virtual int GetStatus(TException exception)
        {
            return (int)_statusCode;
        }

        protected string GetInstance(TException exception)
        {
            // TODO: VC: handling errors that occurred relating to some resources, could have resource/{id}/errors/{errorid}
            // TODO: VC: But no stack trace there, instead stack trace is via having special permissions, stacck trace is then extension
            // and similarly could access /api/errors/{guid}.. this is the thing from log file, but does it make sense to dereference it?

            var guid = Guid.NewGuid();

            // TODO: VC: #177: REST API - Exception Handling - Problem Details - Instance
            var instance = $"urn:error:{guid}";

            return instance;
        }

        protected virtual string GetProblemTypeUri(TException exception)
        {
            return _problemTypeUri;
        }


    }
}