using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.Reflection
{
    public interface ITypeProperty
    {
        string Name { get; }

        Type Type { get; }
    }
}
