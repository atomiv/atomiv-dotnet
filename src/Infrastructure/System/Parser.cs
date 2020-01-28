using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Infrastructure.System
{
    /// <summary>
    /// Parses string data into objects, using specified data types
    /// </summary>
    public class Parser
    {
        private Dictionary<Type, Converter> converters;

        public Parser(Dictionary<Type, Converter> converters)
        {
            this.converters = converters;
        }

        public bool CanParse(Type type)
        {
            return converters.ContainsKey(type);
        }

        public object Parse(string data, Type type)
        {
            if (!CanParse(type))
            {
                throw new NotSupportedException();
            }

            if (data == null)
            {
                return null;
            }

            return converters[type](data);
        }
    }
}