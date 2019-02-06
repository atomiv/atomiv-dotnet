using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Optivem.Platform.Core.Common.Serialization;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class CustomerDtoCsvInputFormatter : TextInputFormatter
    {
        private const string MediaType = "text/csv";

        private readonly ICsvSerializationService _csvSerializationService;

        public CustomerDtoCsvInputFormatter(ICsvSerializationService csvSerializationService)
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


            // NOTE: FAIL
            var response = _csvSerializationService.Deserialize(data, type);


            // NOTE: SUCCEED
            /*
            var response = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "Valentina",
                    LastName = "Cupac",
                },

                new CustomerDto
                {
                    Id = 2,
                    FirstName = "Jelena",
                    LastName = "Cupac",
                }
            };
            */

            // NOTE: FAIL: List`1[System.Object]' to type 'System.Collections.Generic.IEnumerable`1 : new List<object>
            // NOTE: FAIL: Unable to cast object of type 'System.Collections.ArrayList' to type 'System.Collections.Generic.IEnumerable`1[Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models.CustomerDto]'.

            /*
            IList response = new List<object>
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "Valentina",
                    LastName = "Cupac",
                },

                new CustomerDto
                {
                    Id = 2,
                    FirstName = "Jelena",
                    LastName = "Cupac",
                }
            };

            var response2 = response.Cast<CustomerDto>().ToList();

            // IList response3 = (IList)Activator.CreateInstance(typeof(List<CustomerDto>));

            IList response3 = (IList)Activator.CreateInstance(typeof(List<CustomerDto>));

            response3.Add(new CustomerDto
            {
                Id = 1,
                FirstName = "Valentina",
                LastName = "Cupac",
            });

            */

            return InputFormatterResult.Success(response);
        }
    }
}
