using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Optivem.Common.Serialization;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        private const string MediaType = "text/csv";

        private readonly ICsvSerializationService _csvSerializationService;

        public CsvOutputFormatter(ICsvSerializationService csvSerializationService)
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
