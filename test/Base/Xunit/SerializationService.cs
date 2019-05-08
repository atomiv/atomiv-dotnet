﻿using Optivem.Common.Serialization;
using Optivem.Infrastructure.Serialization.CsvHelper;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;
using System.Collections.Generic;

namespace Optivem.Infrastructure.Serialization.All
{
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
                { SerializationFormatType.Json, new JsonSerializationService() },
                { SerializationFormatType.Csv, new CsvSerializationService() },
            };
        }

        #endregion
    }
}
