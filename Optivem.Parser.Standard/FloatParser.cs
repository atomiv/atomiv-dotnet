using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Standard
{
    public class FloatParser : BaseParser<float?>
    {
        protected override float? ParseInner(string value)
        {
            return float.Parse(value);
        }
    }
}
