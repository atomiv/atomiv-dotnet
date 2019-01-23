using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Parsing
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}
