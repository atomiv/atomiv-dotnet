﻿namespace Optivem.Platform.Infrastructure.Common.Parsing.Default
{
    public class LongParser : BaseParser<long?>
    {
        protected override long? ParseInner(string value)
        {
            return long.Parse(value);
        }
    }
}
