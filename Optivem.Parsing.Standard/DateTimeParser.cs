using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class DateTimeParser : BaseParser<DateTime?>
    {
        protected override DateTime? ParseInner(string value)
        {
            return DateTime.Parse(value);
        }
    }
}
