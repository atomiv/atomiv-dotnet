using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.Parsing
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}
