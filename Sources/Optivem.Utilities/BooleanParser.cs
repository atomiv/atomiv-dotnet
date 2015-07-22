using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Utilities
{
    /// <summary>
    /// Parser for boolean (binary) values
    /// </summary>
    public class BooleanParser
    {
        private static HashSet<string> empty = new HashSet<string>();

        public BooleanParser(HashSet<string> trueStrings, HashSet<string> falseStrings)
        {
            this.TrueStrings = trueStrings;
            this.FalseStrings = falseStrings;

            // TODO: Check that these are mutually exclusive
        }

        public BooleanParser()
            : this(empty, empty) { }

        public HashSet<string> TrueStrings { get; private set; }

        public HashSet<string> FalseStrings { get; private set; }

        public bool ParseBoolean(string data)
        {
            bool result = false;
            bool succeed = bool.TryParse(data, out result);

            if(succeed)
            {
                return result;
            }
            
            if(TrueStrings.Contains(data))
            {
                return true;
            }

            if(FalseStrings.Contains(data))
            {
                return false;
            }

            throw new ArgumentException("Failed to convert " + data + " to a boolean value");
        }
    }
}
