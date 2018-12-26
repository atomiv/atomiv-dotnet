using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class LongParser : BaseParser<long?>
    {
        protected override long? ParseInner(string value)
        {
            return long.Parse(value);
        }
    }
}
