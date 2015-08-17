using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Immerest
{
    /// <summary>
    /// Parser for Enum types
    /// </summary>
    public class EnumParser
    {
        public EnumParser(bool ignoreCase = false)
        {
            this.IgnoreCase = ignoreCase;
        }

        public bool IgnoreCase { get; private set; }

        public object ParseEnum(string data, Type type)
        {
            return Enum.Parse(type, data, IgnoreCase);
        }

        public T ParseEnum<T>(string data)
        {
            return (T)ParseEnum(data, typeof(T));
        }
    }
}
