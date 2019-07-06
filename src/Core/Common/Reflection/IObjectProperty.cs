namespace Optivem.Framework.Core.Common.Reflection
{
    public interface IObjectProperty
    {
        ITypeProperty TypeProperty { get; }

        object Value { get; }
    }
}
