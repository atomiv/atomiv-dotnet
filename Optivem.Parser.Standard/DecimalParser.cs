using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Standard
{
    public class DecimalParser : BaseParser<decimal?>
    {
        protected override decimal? ParseInner(string value)
        {
            return decimal.Parse(value);
        }
    }
}
