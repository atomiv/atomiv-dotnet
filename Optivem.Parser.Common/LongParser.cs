using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class LongParser : BaseParser<long?>
    {
        protected override long? ParseInner(string value)
        {
            return long.Parse(value);
        }
    }
}
