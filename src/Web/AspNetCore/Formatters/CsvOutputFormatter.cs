using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Optivem.Atomiv.Core.Common.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Web.AspNetCore
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        private const string MediaType = "text/csv";

        private readonly ICsvSerializer _csvSerializationService;

        public CsvOutputFormatter(ICsvSerializer csvSerializationService)
        {
            _csvSerializationService = csvSerializationService;

            var mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(MediaType);

            SupportedMediaTypes.Add(mediaTypeHeaderValue);
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var obj = context.Object;
            var type = context.ObjectType;
            var data = (IEnumerable<object>)obj;

            var response = _csvSerializationService.Serialize(data, type);

            return context.HttpContext.Response.WriteAsync(response, selectedEncoding);
        }
    }
}