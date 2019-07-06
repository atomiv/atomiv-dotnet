using Optivem.Framework.Core.Common.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.System.Reflection
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
