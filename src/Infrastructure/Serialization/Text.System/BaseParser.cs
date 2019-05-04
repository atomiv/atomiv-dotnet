using Optivem.Common.Serialization;

namespace Optivem.Infrastructure.Serialization.Text.System
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
