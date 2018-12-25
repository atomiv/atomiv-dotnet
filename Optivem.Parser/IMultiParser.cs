using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parser
{
    public interface IMultiParser
    {
        T Parse<T>(string value);
    }
}
