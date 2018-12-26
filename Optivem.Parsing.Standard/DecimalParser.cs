using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class DecimalParser : BaseParser<decimal?>
    {
        protected override decimal? ParseInner(string value)
        {
            return decimal.Parse(value);
        }
    }
}
