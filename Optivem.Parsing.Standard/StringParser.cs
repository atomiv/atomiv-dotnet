using Optivem.Parsing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Standard
{
    public class StringParser : BaseParser<string>
    {
        protected override string ParseInner(string value)
        {
            return value;
        }
    }
}
