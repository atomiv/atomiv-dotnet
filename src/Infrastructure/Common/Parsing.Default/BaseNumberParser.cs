using System;
using System.Globalization;

namespace Optivem.Framework.Infrastructure.Common.Parsing.Default
{
    public abstract class BaseNumberParser<T> : BaseParser<T>
    {
        public BaseNumberParser(NumberStyles? numberStyles = null, IFormatProvider formatProvider = null)
        {
            NumberStyles = numberStyles;
            FormatProvider = formatProvider;
        }

        public IFormatProvider FormatProvider { get; private set; }

        public NumberStyles? NumberStyles { get; private set; }

        protected override T ParseInner(string value)
        {
            if(NumberStyles != null && FormatProvider != null)
            {
                return ParseNumber(value, NumberStyles.Value, FormatProvider);
            }

            if(NumberStyles != null)
            {
                return ParseNumber(value, NumberStyles.Value);
            }

            if(FormatProvider != null)
            {
                return ParseNumber(value, FormatProvider);
            }

            return ParseNumber(value);
        }

        protected abstract T ParseNumber(string value);

        protected abstract T ParseNumber(string value, IFormatProvider formatProvider);

        protected abstract T ParseNumber(string value, NumberStyles numberStyles);

        protected abstract T ParseNumber(string value, NumberStyles numberStyles, IFormatProvider formatProvider);

    }
}
