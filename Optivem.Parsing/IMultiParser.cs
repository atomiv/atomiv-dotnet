using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing
{
    public interface IMultiParser
    {
        T Parse<T>(string value);
    }
}
