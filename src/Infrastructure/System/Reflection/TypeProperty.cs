using Atomiv.Core.Common.Reflection;
using System;

namespace Atomiv.Infrastructure.System.Reflection
{
    public class TypeProperty : ITypeProperty
    {
        public TypeProperty(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public Type Type { get; }
    }
}