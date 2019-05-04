using System;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public class ExceptionProblemDetailsFactoryRegistry
    {
        private readonly IExceptionProblemDetailsFactory _defaultFactory;
        private readonly Dictionary<Type, IExceptionProblemDetailsFactory> _factories;
        private readonly List<Type> _types;

        public ExceptionProblemDetailsFactoryRegistry(IExceptionProblemDetailsFactory defaultFactory)
        {
            _defaultFactory = defaultFactory;
            _factories = new Dictionary<Type, IExceptionProblemDetailsFactory>();
            _types = new List<Type>();
        }

        public void Add(Type type, IExceptionProblemDetailsFactory factory)
        {
            _factories.Add(type, factory);
            _types.Add(type);
        }

        public IExceptionProblemDetailsFactory Get(object exception)
        {
            var exceptionType = exception.GetType();

            // TODO: VC: Check this, instead should ensure that Exception is set as last, or checking if can convert to... 
            var type = _types.SingleOrDefault(e => e == exceptionType);

            if(type == null)
            {
                return _defaultFactory;
            }

            return _factories[type];
        }
    }
}
