using Optivem.Framework.Core.Common.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.Framework.Infrastructure.System.Reflection
{
    public class PropertyFactory : IPropertyFactory
    {
        public IEnumerable<ITypeProperty> Create<TRecord>()
        {
            var factory = new PropertyFactory<TRecord>();
            return factory.Create();
        }

        public IEnumerable<IObjectProperty> Create<TRecord>(TRecord record)
        {
            var factory = new PropertyFactory<TRecord>();
            return factory.Create(record);
        }
    }

    public class PropertyFactory<TRecord> : IPropertyFactory<TRecord>
    {
        private readonly Type _type;
        private readonly PropertyInfo[] _propertyInfos;
        private readonly List<ITypeProperty> _typeProperties;
        private readonly Dictionary<string, ITypeProperty> _typePropertyMap;

        public PropertyFactory()
        {
            _type = typeof(TRecord);
            _propertyInfos = _type.GetProperties();
            _typeProperties = _propertyInfos.Select(e => Create(e)).ToList();
            _typePropertyMap = _typeProperties.ToDictionary(e => e.Name, e => e);
        }

        public IEnumerable<ITypeProperty> Create()
        {
            return _typeProperties;
        }

        public IEnumerable<IObjectProperty> Create(TRecord record)
        {
            return _propertyInfos.Select(e => Create(e, record));
        }



        private ITypeProperty Create(PropertyInfo propertyInfo)
        {
            var name = propertyInfo.Name;
            var type = propertyInfo.PropertyType;
            return new TypeProperty(name, type);
        }

        private IObjectProperty Create(PropertyInfo propertyInfo, TRecord record)
        {
            var name = propertyInfo.Name;
            var typeProperty = _typePropertyMap[name];
            var value = propertyInfo.GetValue(record, null);

            return new ObjectProperty(typeProperty, value);
        }
    }
}
