using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Core.Common.Reflection
{
    public interface IPropertyMapper
    {
        IEnumerable<ITypeProperty> GetTypeProperties<T>();

        IEnumerable<IObjectProperty> GetObjectProperties<T>(T obj);

        string ToString<T>(T obj);
    }

    public interface IPropertyMapper<T>
    {
        IEnumerable<ITypeProperty> GetTypeProperties();

        IEnumerable<IObjectProperty> GetObjectProperties(T obj);

        ITypeProperty GetTypeProperty<U>(Func<T, U> propertyGetter);

        IObjectProperty GetObjectProperty<U>(Func<T, U> propertyGetter);
    }
}