using Optivem.Parser.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Common
{
    public class StringParser : BaseParser<string>
    {
        protected override string ParseInner(string value)
        {
            return value;
        }
    }
}
