using Microsoft.AspNetCore.Http;
using Optivem.Framework.Core.Common.Serialization;
using System.Threading.Tasks;

namespace Optivem.Framework.Web.AspNetCore
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