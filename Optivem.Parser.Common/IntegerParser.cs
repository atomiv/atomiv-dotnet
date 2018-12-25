using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class IntegerParser : BaseParser<int?>
    {
        protected override int? ParseInner(string value)
        {
            return int.Parse(value);
        }
    }
}
