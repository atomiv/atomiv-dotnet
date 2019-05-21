namespace Optivem.Infrastructure.Serialization.System
{
    public class LongParser : BaseParser<long?>
    {
        protected override long? ParseInner(string value)
        {
            return long.Parse(value);
        }
    }
}