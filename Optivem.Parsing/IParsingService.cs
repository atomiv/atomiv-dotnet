using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}
