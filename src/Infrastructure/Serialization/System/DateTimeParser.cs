using System;
using System.Globalization;

namespace Optivem.Infrastructure.Serialization.System
{
    public class DateTimeParser : BaseParser<DateTime?>
    {
        public DateTimeParser(string format = null)
        {
            Format = format;
        }

        public string Format { get; private set; }

        protected override DateTime? ParseInner(string value)
        {
            if (Format != null)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                return DateTime.ParseExact(value, Format, provider);
            }

            return DateTime.Parse(value);
        }
    }
}