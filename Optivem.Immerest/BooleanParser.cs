using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Immerest
{
    /// <summary>
    /// Parser for boolean (binary) values
    /// </summary>
    public class BooleanParser
    {
        private static HashSet<string> empty = new HashSet<string>();

        /// <summary>
        /// Creates an instance of a boolean parser
        /// </summary>
        /// <param name="trueStrings">Set of custom strings representing the boolean "true" value</param>
        /// <param name="falseStrings">Set of custom strings representing the boolean "false" value</param>
        public BooleanParser(HashSet<string> trueStrings, HashSet<string> falseStrings)
        {
            this.TrueStrings = trueStrings;
            this.FalseStrings = falseStrings;
        }

        /// <summary>
        /// Creates an instance of a boolean parser
        /// </summary>
        public BooleanParser()
            : this(empty, empty) { }

        /// <summary>
        /// Set of custom strings representing the "true" value
        /// </summary>
        public HashSet<string> TrueStrings { get; private set; }

        /// <summary>
        /// Set of custom strings representing the "false" value
        /// </summary>
        public HashSet<string> FalseStrings { get; private set; }

        /// <summary>
        /// Converts string data to boolean value
        /// </summary>
        /// <param name="data">Data to be converted</param>
        /// <returns>Converted boolean value</returns>
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
