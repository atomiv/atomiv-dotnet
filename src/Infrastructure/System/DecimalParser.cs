namespace Optivem.Framework.Infrastructure.System
{
    public class DecimalParser : BaseParser<decimal?>
    {
        protected override decimal? ParseInner(string value)
        {
            return decimal.Parse(value);
        }
    }
}