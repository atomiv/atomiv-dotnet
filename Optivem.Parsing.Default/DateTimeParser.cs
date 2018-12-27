using System;

namespace Optivem.Parsing.Default
{
    public class DateTimeParser : BaseParser<DateTime?>
    {
        protected override DateTime? ParseInner(string value)
        {
            return DateTime.Parse(value);
        }
    }
}
