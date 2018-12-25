using Optivem.Parser.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Standard
{
    public class LongParser : BaseParser<long?>
    {
        protected override long? ParseInner(string value)
        {
            return long.Parse(value);
        }
    }
}
