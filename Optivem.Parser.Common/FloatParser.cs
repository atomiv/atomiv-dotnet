using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class FloatParser : BaseParser<float?>
    {
        protected override float? ParseInner(string value)
        {
            return float.Parse(value);
        }
    }
}
