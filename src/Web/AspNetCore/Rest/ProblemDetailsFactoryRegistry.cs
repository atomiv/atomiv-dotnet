using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class ProblemDetailsFactoryRegistry
    {
        private readonly IProblemDetailsFactory _defaultFactory;
        private readonly Dictionary<Type, IProblemDetailsFactory> _factories;
        private readonly List<Type> _types;

        public ProblemDetailsFactoryRegistry(IProblemDetailsFactory defaultFactory)
        {
            _defaultFactory = defaultFactory;
            _factories = new Dictionary<Type, IProblemDetailsFactory>();
            _types = new List<Type>();
        }

        public void Add(Type type, IProblemDetailsFactory factory)
        {
            _factories.Add(type, factory);
            _types.Add(type);
        }

        public IProblemDetailsFactory Get(object exception)
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
