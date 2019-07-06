using System.Collections.Generic;

namespace Optivem.Framework.Core.Common.Reflection
{
    public interface IPropertyFactory
    {
        IEnumerable<ITypeProperty> Create<TRecord>();

        IEnumerable<IObjectProperty> Create<TRecord>(TRecord record);
    }

    public interface IPropertyFactory<TRecord>
    {
        IEnumerable<ITypeProperty> Create();

        IEnumerable<IObjectProperty> Create(TRecord record);
    }
}
