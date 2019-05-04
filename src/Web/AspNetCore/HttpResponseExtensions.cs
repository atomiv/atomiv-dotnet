using Microsoft.AspNetCore.Http;
using Optivem.Common.Serialization;
using System.Threading.Tasks;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public static class HttpResponseExtensions
    {
        public static Task WriteJsonAsync<T>(this HttpResponse response, T data, IJsonSerializationService jsonSerializationService)
        {
            var json = jsonSerializationService.Serialize(data);

            // TODO: VC: make configurable
            response.ContentType = "application/json";
            return response.WriteAsync(json);
        }
    }
}
