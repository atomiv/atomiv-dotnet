using CsvHelper;
using Optivem.Platform.Core.Common.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper
{
    public class CsvSerializationService : ICsvSerializationService
    {
        // TODO: VC: Constructor enable type-based specific serializers that override reflection mechanism

        public string Serialize(object data, Type type)
        {
            var enumerable = (IEnumerable)data;

            using (var textWriter = new StringWriter())
            {
                using (var writer = new CsvWriter(textWriter))
                {
                    writer.WriteRecords(enumerable);
                    return textWriter.ToString();
                }
            }
        }

        public object Deserialize(string data, Type type)
        {
            var recordType = GetElementType(type);

            using (var textReader = new StringReader(data))
            {
                using (var reader = new CsvReader(textReader))
                {
                    return reader.GetRecords(recordType).ToList();
                }
            }
        }

        #region Helper

        // TODO: VC: Transfer to Reflection implementation, in Infrastructure create Reflection project

        private static Type GetElementType(Type type)
        {
            if (type.IsArray)
            {
                return type.GetElementType();
            }

            var enumerableType = typeof(IEnumerable<>);

            if (type.IsGenericType && type.GetGenericTypeDefinition() == enumerableType)
            {
                return type.GetGenericArguments().Single();
            }

            var elementType = type.GetInterfaces()
                .Where(e => e.IsGenericType
                    && e.GetGenericTypeDefinition() == enumerableType)
                .Select(e => e.GenericTypeArguments.First())
                .FirstOrDefault();

            if (elementType != null)
            {
                return elementType;
            }

            // TODO: VC: Custom exception

            // TODO: Check conversion
            throw new ArgumentException($"Type {type} cannot be converted to IEnumerable");
        }

        public string Serialize<T>(T data)
        {
            throw new NotSupportedException("Can only serialize IEnumerable data");
        }

        public T Deserialize<T>(string data)
        {
            throw new NotSupportedException("Can only deserialize IEnumerable data");
        }

        public string SerializeEnumerable<E>(IEnumerable<E> data)
        {
            using (var textWriter = new StringWriter())
            {
                using (var writer = new CsvWriter(textWriter, true))
                {
                    writer.WriteRecords(data);
                    return textWriter.ToString();
                }
            }
        }

        public IEnumerable<E> DeserializeEnumerable<E>(string data)
        {
            using (var textReader = new StringReader(data))
            {
                using (var reader = new CsvReader(textReader))
                {
                    return reader.GetRecords<E>().ToList();
                }
            }
        }

        #endregion

    }
}
