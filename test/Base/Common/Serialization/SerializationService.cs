using Optivem.Core.Common.Serialization;
using System.Collections.Generic;

namespace Optivem.Test.Common.Serialization
{
    // TODO: VC: Check to delete this

    public class SerializationService : ISerializationService
    {
        private readonly Dictionary<SerializationFormatType, IFormatSerializationService> _formatSerializationServices;

        public SerializationService(Dictionary<SerializationFormatType, IFormatSerializationService> formatSerializationServices)
        {
            _formatSerializationServices = formatSerializationServices;
        }

        public SerializationService()
            : this(CreateFormatSerializationServices())
        {
        }

        public string Serialize<T>(T data, SerializationFormatType format)
        {
            var formatSerializationService = _formatSerializationServices[format];
            return formatSerializationService.Serialize(data);
        }

        public T Deserialize<T>(string data, SerializationFormatType format)
        {
            var formatSerializationService = _formatSerializationServices[format];
            return formatSerializationService.Deserialize<T>(data);
        }

        #region Helper

        private static Dictionary<SerializationFormatType, IFormatSerializationService> CreateFormatSerializationServices()
        {
            return new Dictionary<SerializationFormatType, IFormatSerializationService>
            {
                { SerializationFormatType.Json, SerializationServiceFactory.CreateJsonSerializationService() },
                { SerializationFormatType.Csv, SerializationServiceFactory.CreateCsvSerializationService() },
            };
        }

        #endregion Helper
    }
}
