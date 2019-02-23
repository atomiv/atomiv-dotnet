using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public abstract class BaseProblemDetailsFactory<TException, TProblemDetails>
        : IProblemDetailsFactory<TException, TProblemDetails>
        where TException : Exception
        where TProblemDetails : ProblemDetails, new()
    {
        public TProblemDetails Create(TException exception)
        {
            var problemDetails = new TProblemDetails();
            problemDetails.Title = GetTitle(exception);
            problemDetails.Status = GetStatus(exception);
            problemDetails.Detail = GetDetail(exception);
            problemDetails.Instance = GetInstance(exception);
            problemDetails.Type = GetProblemTypeUri(exception);

            return problemDetails;
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
            // TODO: VC: handling errors that occurred relating to some resources, could have resource/{id}/errors/{errorid}
            // TODO: VC: But no stack trace there, instead stack trace is via having special permissions, stacck trace is then extension
            // and similarly could access /api/errors/{guid}.. this is the thing from log file, but does it make sense to dereference it?

            var guid = Guid.NewGuid();

            // TODO: VC: #177: REST API - Exception Handling - Problem Details - Instance
            var instance = $"urn:optivem:error:{guid}";

            return instance;
        }

        protected abstract string GetProblemTypeUri(TException exception);


    }
}
