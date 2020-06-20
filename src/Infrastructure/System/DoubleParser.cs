namespace Atomiv.Infrastructure.System
{
    public class DoubleParser : BaseParser<double?>
    {
        protected override double? ParseInner(string value)
        {
            return double.Parse(value);
        }
    }
}