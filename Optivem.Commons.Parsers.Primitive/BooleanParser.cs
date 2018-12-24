using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Commons.Parser.Basic
{
    /// <summary>
    /// Parser for boolean (binary) values
    /// </summary>
    public class BooleanParser : IParser<bool>
    {
        /// <summary>
        /// Creates an instance of a boolean parser
        /// </summary>
        /// <param name="trueStrings">Set of custom strings representing the boolean "true" value</param>
        /// <param name="falseStrings">Set of custom strings representing the boolean "false" value</param>
        public BooleanParser(Dictionary<string, bool> mapping = null)
        {
            this.Mapping = mapping;
        }

        /// <summary>
        /// Mapping of strings to boolean values
        /// </summary>
        public Dictionary<string, bool> Mapping { get; private set; }

        /// <summary>
        /// Converts string data to boolean value
        /// </summary>
        /// <param name="data">Data to be converted</param>
        /// <returns>Converted boolean value</returns>
        public bool ParseBoolean(string data)
        {
            bool result = false;
            bool succeed = bool.TryParse(data, out result);

            if (succeed)
            {
                return result;
            }

            if (Mapping != null && Mapping.ContainsKey(data))
            {
                return Mapping[data];
            }

            throw new ArgumentException("Failed to convert " + data + " to a boolean value");
        }
    }
}
