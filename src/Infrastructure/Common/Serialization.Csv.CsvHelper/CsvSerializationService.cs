using CsvHelper;
using Optivem.Platform.Core.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper
{
    public class CsvSerializationService : IEnumerableSerializationService
    {
        private readonly ICsvReaderFactory _readerFactory;

        public CsvSerializationService(ICsvReaderFactory readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public IEnumerable<T> Deserialize<T>(IEnumerable<string> records)
        {
            using (var reader = _readerFactory.Create(records))
            {
                return reader.GetRecords<T>().ToList();
            }
        }

        public IEnumerable<T> Deserialize<T>(string records)
        {
            using (var reader = _readerFactory.Create(records))
            {
                return reader.GetRecords<T>().ToList();
            }
        }

        public string Serialize<T>(IEnumerable<T> records)
        {
            throw new NotImplementedException();
        }
    }
}
