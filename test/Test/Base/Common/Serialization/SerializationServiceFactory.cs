using Optivem.Core.Common.Serialization;
using Optivem.Infrastructure.CsvHelper;
using Optivem.Infrastructure.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.Serialization
{
    public static class SerializationServiceFactory
    {
        public static IJsonSerializationService CreateJsonSerializationService()
        {
            return new JsonSerializationService();
        }

        public static ICsvSerializationService CreateCsvSerializationService()
        {
            return new CsvSerializationService();
        }
    }
}
