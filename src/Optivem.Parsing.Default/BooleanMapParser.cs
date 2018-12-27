using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Default
{
    public class BooleanMapParser : IParser<bool?>
    {
        private Dictionary<string, bool> mapping;

        public BooleanMapParser(Dictionary<string, bool> mapping)
        {
            this.mapping = mapping;
        }

        public bool? Parse(string value)
        {
            // TODO: VC: Exception handling if not in map

            return mapping[value];
        }
    }
}
