using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class DoubleParser : BaseParser<double?>
    {
        protected override double? ParseInner(string value)
        {
            return double.Parse(value);
        }
    }
}
