using Microsoft.AspNetCore.Mvc;
using System;

namespace Optivem.Atomiv.Web.AspNetCore
{
    public class ExceptionProblemDetailsFactory : IExceptionProblemDetailsFactory
    {
        private readonly ExceptionProblemDetailsFactoryRegistry _registry;

        public ExceptionProblemDetailsFactory(ExceptionProblemDetailsFactoryRegistry registry)
        {
            _registry = registry;
        }

        public ProblemDetails Create(Exception exception)
        {
            var factory = _registry.Get(exception);
            return factory.Create(exception);
        }
    }
}