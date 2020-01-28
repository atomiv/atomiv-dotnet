using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Optivem.Atomiv.Core.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Web.AspNetCore
{
    public class CsvInputFormatter : TextInputFormatter
    {
        private const string MediaType = "text/csv";

        private readonly ICsvSerializer _csvSerializationService;

        public CsvInputFormatter(ICsvSerializer csvSerializationService)
        {
            _csvSerializationService = csvSerializationService;

            var mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(MediaType);

            SupportedMediaTypes.Add(mediaTypeHeaderValue);
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var stream = context.HttpContext.Request.Body;

            string data = null;

            using (var reader = context.ReaderFactory(stream, encoding))
            {
                data = await reader.ReadToEndAsync();
            }

            // TODO: VC: Can also have PlainText reader, which just reads the entire string and then parses it

            Type type = context.ModelType;

            var response = _csvSerializationService.Deserialize(data, type);

            return InputFormatterResult.Success(response);
        }
    }
}