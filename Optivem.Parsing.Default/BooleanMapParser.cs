using System;

namespace Optivem.Parsing.Default
{
    // TODO: VC: Check if need map <string, boolean> for several true and several false values

    public class BooleanMapParser : BaseParser<bool?>
    {
        private BooleanMapParser(string trueString, string falseString)
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
