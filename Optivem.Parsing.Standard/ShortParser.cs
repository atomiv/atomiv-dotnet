using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class ShortParser : BaseParser<short?>
    {
        protected override short? ParseInner(string value)
        {
            return short.Parse(value);
        }
    }
}
