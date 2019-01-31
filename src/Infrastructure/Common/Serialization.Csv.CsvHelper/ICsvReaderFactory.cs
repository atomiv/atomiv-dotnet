using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper
{
    public interface ICsvReaderFactory
    {
        CsvReader Create(TextReader textReader);

        CsvReader Create(string content);

        CsvReader Create(IEnumerable<string> content);
    }
}
