using System;

namespace Atomiv.Core.Common.Reflection
{
    public interface ITypeProperty
    {
        string Name { get; }

        Type Type { get; }
    }
}