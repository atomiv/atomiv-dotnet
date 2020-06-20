namespace Atomiv.Infrastructure.System
{
    public class FloatParser : BaseParser<float?>
    {
        protected override float? ParseInner(string value)
        {
            return float.Parse(value);
        }
    }
}