using Optivem.Core.Common.Serialization;
using System.Collections.Generic;

namespace Optivem.Infrastructure.System
{
    public class EnumStringParser<T> : IParser<T>
    {
        private Dictionary<string, T> map;

        public EnumStringParser(Dictionary<string, T> map)
        {
            this.map = map;
        }

        public T Parse(string value)
        {
            return map[value];
        }
    }
}