using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.Parsing
{
    public interface IParser
    {
        object Parse(string value);
    }

    public interface IParser<T>
    {
        T Parse(string value);
    }
}
