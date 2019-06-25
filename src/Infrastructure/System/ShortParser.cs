﻿namespace Optivem.Framework.Infrastructure.System
{
    public class ShortParser : BaseParser<short?>
    {
        protected override short? ParseInner(string value)
        {
            return short.Parse(value);
        }
    }
}