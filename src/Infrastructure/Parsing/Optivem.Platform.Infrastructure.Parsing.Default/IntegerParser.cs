﻿namespace Optivem.Platform.Infrastructure.Common.Parsing.Default
{
    public class IntegerParser : BaseParser<int?>
    {
        protected override int? ParseInner(string value)
        {
            return int.Parse(value);
        }
    }
}
