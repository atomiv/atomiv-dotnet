using Optivem.Common.Serialization;
using System.Collections.Generic;

namespace Optivem.Infrastructure.Serialization.Text.System
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
