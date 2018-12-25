using Optivem.Parser.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Standard
{
    public class IntegerParser : BaseParser<int?>
    {
        protected override int? ParseInner(string value)
        {
            return int.Parse(value);
        }
    }
}
