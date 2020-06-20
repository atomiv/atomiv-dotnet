using Atomiv.Core.Common.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Atomiv.Infrastructure.System.Reflection
{
    public class PropertyMapper : IPropertyMapper
    {
        public static PropertyMapper Instance = new PropertyMapper();

        public IEnumerable<ITypeProperty> GetTypeProperties<TRecord>()
        {
            var factory = new PropertyMapper<TRecord>();
            return factory.GetTypeProperties();
        }

        public IEnumerable<IObjectProperty> GetObjectProperties<TRecord>(TRecord record)
        {
            var factory = new PropertyMapper<TRecord>();
            return factory.GetObjectProperties(record);
        }

        public string ToString<T>(T obj)
        {
            var properties = GetObjectProperties(obj);
            return string.Join(", ", properties);
        }
    }

    public class PropertyMapper<T> : IPropertyMapper<T>
    {
        private readonly Type _type;
        private readonly PropertyInfo[] _propertyInfos;
        private readonly List<ITypeProperty> _typeProperties;
        private readonly Dictionary<string, ITypeProperty> _typePropertyMap;

        public PropertyMapper()
        {
            _type = typeof(T);
            _propertyInfos = _type.GetProperties();
            _typeProperties = _propertyInfos.Select(e => Create(e)).ToList();
            _typePropertyMap = _typeProperties.ToDictionary(e => e.Name, e => e);
        }

        // TODO: VC: DELETE

        /*
        private static List<PropertyInfo> GetPropertyInfos(Type type)
        {
            var properties = new List<PropertyInfo>();

            if(type.BaseType != typeof(object))
            {
                var innerProperties = GetPropertyInfos(type.BaseType);
                properties.AddRange(innerProperties);
            }

            properties.AddRange(type.GetProperties());

            return properties;

            // return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        */

        public ITypeProperty GetTypeProperty<U>(Func<T, U> propertyGetter)
        {
            throw new NotImplementedException();
        }

        public IObjectProperty GetObjectProperty<U>(Func<T, U> propertyGetter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITypeProperty> GetTypeProperties()
        {
            return _typeProperties;
        }

        public IEnumerable<IObjectProperty> GetObjectProperties(T obj)
        {
            return _propertyInfos.Select(e => Create(e, obj));
        }

        private ITypeProperty Create(PropertyInfo propertyInfo)
        {
            var name = propertyInfo.Name;
            var type = propertyInfo.PropertyType;
            return new TypeProperty(name, type);
        }

        private IObjectProperty Create(PropertyInfo propertyInfo, T obj)
        {
            var name = propertyInfo.Name;
            var typeProperty = _typePropertyMap[name];
            var value = propertyInfo.GetValue(obj, null);

            return new ObjectProperty(typeProperty, value);
        }
    }
}