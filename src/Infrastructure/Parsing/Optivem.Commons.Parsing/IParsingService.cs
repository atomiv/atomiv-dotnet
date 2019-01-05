using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Commons.Parsing
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}
