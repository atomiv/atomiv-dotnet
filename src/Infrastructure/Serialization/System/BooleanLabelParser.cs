using System;

namespace Optivem.Infrastructure.Serialization.System
{
    public class BooleanLabelParser : BaseParser<bool?>
    {
        private BooleanLabelParser(string trueString, string falseString)
        {
            TrueString = trueString;
            FalseString = falseString;
        }

        public string TrueString { get; private set; }

        public string FalseString { get; private set; }

        protected override bool? ParseInner(string value)
        {
            if (value == TrueString)
            {
                return true;
            }

            if (value == FalseString)
            {
                return false;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}