using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atomiv.Web.AspNetCore
{
    public class RootExceptionProblemDetailsFactory : IRootExceptionProblemDetailsFactory
    {
        private readonly IEnumerable<IExceptionProblemDetailsFactory> _factories;

        public RootExceptionProblemDetailsFactory(IEnumerable<IExceptionProblemDetailsFactory> factories)
        {
            _factories = factories;
        }

        public ProblemDetails Create(Exception exception)
        {
            var factory = GetFactory(exception);

            if(factory == null)
            {
                return null;
            }

            return factory.Create(exception);
        }

        private IExceptionProblemDetailsFactory GetFactory(Exception exception)
        {
            foreach(var factory in _factories)
            {
                if(factory.CanCreate(exception))
                {
                    return factory;
                }
            }

            return null;
        }
    }
}