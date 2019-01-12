using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Parsing
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}
