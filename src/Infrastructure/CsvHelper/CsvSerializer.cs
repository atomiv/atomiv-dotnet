using CsvHelper;
using CsvHelper.Configuration;
using Atomiv.Core.Common.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Atomiv.Infrastructure.CsvHelper
{
    public class CsvSerializer : ICsvSerializer
    {
        // TODO: VC: Constructor enable type-based specific serializers that override reflection mechanism

        // TODO: VC: Check culture info

        public string Serialize(object data, Type type)
        {
            var enumerable = (IEnumerable)data;

            using (var textWriter = new StringWriter())
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    NewLine = Environment.NewLine
                };
                using (var writer = new CsvWriter(textWriter, config))
                {
                    writer.WriteRecords(enumerable);
                    return textWriter.ToString();
                }
            }
        }

        public object Deserialize(string data, Type type)
        {
            var elementType = GetElementType(type);

            using (var textReader = new StringReader(data))
            {
                using (var reader = new CsvReader(textReader, CultureInfo.InvariantCulture))
                {
                    // TODO: VC: Cleanup

                    // return reader.GetRecords(recordType).ToList();
                    var result = reader.GetRecords(elementType).ToList();
                    // var changedType = ChangeElementType(result, elementType);
                    var changedType = GetList(result, type, elementType);
                    return changedType;
                }
            }
        }

        #region Helper

        // TODO: VC: Transfer to Reflection implementation, in Infrastructure create Reflection project

        private static List<object> ChangeElementType(List<object> list, Type elementType)
        {
            return list.Select(e => Convert.ChangeType(e, elementType)).ToList();
        }

        private static IList GetList(List<object> list, Type type, Type elementType)
        {
            var result = (IList)Activator.CreateInstance(type);

            list.ForEach(e => result.Add(e));

            return result;
        }

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
            var type = typeof(T);
            return Serialize(data, type);
        }

        public T Deserialize<T>(string data)
        {
            // TODO: VC: Check that type is IEnumerable
            var type = typeof(T);
            return (T)Deserialize(data, type);
        }

        public string SerializeEnumerable<E>(IEnumerable<E> data)
        {
            using (var textWriter = new StringWriter())
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    NewLine = Environment.NewLine
                };
                using (var writer = new CsvWriter(textWriter, config, true))
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
                using (var reader = new CsvReader(textReader, CultureInfo.InvariantCulture))
                {
                    return reader.GetRecords<E>().ToList();
                }
            }
        }

        #endregion Helper
    }
}