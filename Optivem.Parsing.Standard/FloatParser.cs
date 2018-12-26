using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class FloatParser : BaseParser<float?>
    {
        protected override float? ParseInner(string value)
        {
            return float.Parse(value);
        }
    }
}
