namespace Optivem.Infrastructure.System
{
    public class IntegerParser : BaseParser<int?>
    {
        protected override int? ParseInner(string value)
        {
            return int.Parse(value);
        }
    }
}