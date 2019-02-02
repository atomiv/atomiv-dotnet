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

        public string Serialize<T>(IEnumerable<T> records)
        {
            using (var textWriter = new StringWriter())
            {
                using (var writer = new CsvWriter(textWriter, true))
                {
                    writer.WriteRecords(records);
                    return textWriter.ToString();
                }
            }
        }

        public string Serialize(IEnumerable<object> records, Type recordType)
        {
            using (var textWriter = new StringWriter())
            {
                using (var writer = new CsvWriter(textWriter))
                {
                    writer.WriteRecords(records);
                    return textWriter.ToString();
                }
            }
        }

        public IEnumerable<T> Deserialize<T>(string records)
        {
            using (var textReader = new StringReader(records))
            {
                using (var reader = new CsvReader(textReader))
                {
                    return reader.GetRecords<T>().ToList();
                }
            }
        }

        public IEnumerable<object> Deserialize(string records, Type recordType)
        {
            using (var textReader = new StringReader(records))
            {
                using (var reader = new CsvReader(textReader))
                {
                    return reader.GetRecords(recordType).ToList();
                }
            }
        }
    }
}
