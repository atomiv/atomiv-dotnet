using Microsoft.AspNetCore.Http;
using Atomiv.Core.Common.Serialization;
using System.Threading.Tasks;

namespace Atomiv.Web.AspNetCore
{
    public static class HttpResponseExtensions
    {
        public static Task WriteJsonAsync<T>(this HttpResponse response, T data, IJsonSerializer jsonSerializationService)
        {
            var json = jsonSerializationService.Serialize(data);

            // TODO: VC: make configurable
            response.ContentType = "application/json";
            return response.WriteAsync(json);
        }
    }
}