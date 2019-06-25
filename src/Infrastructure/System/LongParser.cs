namespace Optivem.Framework.Infrastructure.System
{
    public class LongParser : BaseParser<long?>
    {
        protected override long? ParseInner(string value)
        {
            return long.Parse(value);
        }
    }
}