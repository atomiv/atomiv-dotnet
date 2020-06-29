using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Domain
{
    public interface IGenerator<T>
    {
        T Next();
    }
}
