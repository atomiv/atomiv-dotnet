using Optivem.Framework.Core.Common.Reflection;

namespace Optivem.Framework.Infrastructure.System.Reflection
{
    public class ObjectProperty : IObjectProperty
    {
        public ObjectProperty(ITypeProperty typeProperty, object value)
        {
            TypeProperty = typeProperty;
            Value = value;
        }

        public ITypeProperty TypeProperty { get; }

        public object Value { get; }
    }
}
