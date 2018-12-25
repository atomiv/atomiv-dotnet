using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class DateTimeParser : BaseParser<DateTime?>
    {
        protected override DateTime? ParseInner(string value)
        {
            return DateTime.Parse(value);
        }
    }
}
