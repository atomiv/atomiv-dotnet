using Optivem.Parser.Base;
using System;

namespace Optivem.Parser.Standard
{
    public class BooleanParser : BaseParser<bool?>
    {
        protected override bool? ParseInner(string value)
        {
            return bool.Parse(value);
        }
    }
}
