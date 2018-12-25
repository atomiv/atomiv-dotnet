using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class DoubleParser : BaseParser<double?>
    {
        protected override double? ParseInner(string value)
        {
            return double.Parse(value);
        }
    }
}
