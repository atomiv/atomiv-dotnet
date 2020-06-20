namespace Atomiv.Core.Common.Reflection
{
    public interface IObjectProperty
    {
        ITypeProperty TypeProperty { get; }

        object Value { get; }

        string ToString();
    }
}