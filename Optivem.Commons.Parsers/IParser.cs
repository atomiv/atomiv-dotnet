using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser
{
    public interface IParser
    {
        T Parse<T>(string value);
    }

    public interface IParser<T>
    {
        T Parse(string value);
    }
}
