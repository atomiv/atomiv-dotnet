using Optivem.Parser.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser.Standard
{
    public class StringParser : BaseParser<string>
    {
        protected override string ParseInner(string value)
        {
            return value;
        }
    }
}
