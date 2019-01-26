namespace Optivem.Platform.Infrastructure.Common.Parsing.Default
{
    public class DoubleParser : BaseParser<double?>
    {
        protected override double? ParseInner(string value)
        {
            return double.Parse(value);
        }
    }
}
