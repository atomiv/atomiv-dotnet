using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class DecimalParser : BaseParser<decimal?>
    {
        protected override decimal? ParseInner(string value)
        {
            return decimal.Parse(value);
        }
    }
}
