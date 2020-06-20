namespace Atomiv.Infrastructure.System
{
    public class BooleanParser : BaseParser<bool?>
    {
        protected override bool? ParseInner(string value)
        {
            return bool.Parse(value);
        }
    }
}