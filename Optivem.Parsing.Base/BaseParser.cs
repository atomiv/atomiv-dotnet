using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Base
{
    public abstract class BaseParser<T> : IParser<T>
    {
        public T Parse(string value)
        {
            if(value == null)
            {
                return default(T);
            }

            return ParseInner(value);
        }

        protected abstract T ParseInner(string value);
    }
}
