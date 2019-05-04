namespace Optivem.Infrastructure.Serialization.Text.System
{
    public class StringParser : BaseParser<string>
    {
        protected override string ParseInner(string value)
        {
            return value;
        }
    }
}
