using System;

namespace Optivem.Framework.Core.Common.Reflection
{
    public interface ITypeProperty
    {
        string Name { get; }

        Type Type { get; }
    }
}