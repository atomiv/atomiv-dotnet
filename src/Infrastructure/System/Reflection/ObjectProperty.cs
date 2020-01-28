using Optivem.Atomiv.Core.Common.Reflection;

namespace Optivem.Atomiv.Infrastructure.System.Reflection
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

        public override string ToString()
        {
            return $"{TypeProperty.Name}: {Value}";
        }
    }
}