using Optivem.Parser.Common.Base;
using System;

namespace Optivem.Parser.Common
{
    public class BooleanParser : BaseParser<bool?>
    {
        protected override bool? ParseInner(string value)
        {
            return bool.Parse(value);
        }
    }
}
