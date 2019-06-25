using Optivem.Framework.Core.Common.Serialization;
using Optivem.Framework.Infrastructure.CsvHelper;
using Optivem.Framework.Infrastructure.NewtonsoftJson;

namespace Optivem.Framework.Test.Common.Serialization
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
