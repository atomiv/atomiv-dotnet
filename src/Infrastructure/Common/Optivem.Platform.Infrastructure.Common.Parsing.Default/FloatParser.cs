namespace Optivem.Platform.Infrastructure.Common.Parsing.Default
{
    public class FloatParser : BaseParser<float?>
    {
        protected override float? ParseInner(string value)
        {
            return float.Parse(value);
        }
    }
}
