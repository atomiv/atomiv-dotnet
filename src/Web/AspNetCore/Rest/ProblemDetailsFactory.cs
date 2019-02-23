using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class ProblemDetailsFactory : IProblemDetailsFactory
    {
        private readonly ProblemDetailsFactoryRegistry _registry;

        public ProblemDetailsFactory(ProblemDetailsFactoryRegistry registry)
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
