namespace Optivem.Infrastructure.Serialization.Text.System
{
    public class ShortParser : BaseParser<short?>
    {
        protected override short? ParseInner(string value)
        {
            return short.Parse(value);
        }
    }
}
