using Optivem.Parsing.Base;
using System;

namespace Optivem.Parsing.Standard
{
    public class BooleanParser : BaseParser<bool?>
    {
        protected override bool? ParseInner(string value)
        {
            return bool.Parse(value);
        }
    }
}
