using Microsoft.AspNetCore.Http;
using Atomiv.Core.Common.Serialization;
using System.Threading.Tasks;

namespace Atomiv.Web.AspNetCore
{
    public static class HttpResponseExtensions
    {
        public static Task WriteJsonAsync<T>(this HttpResponse response, T data, IJsonSerializer serializer)
        {
            var json = serializer.Serialize(data);

            // TODO: VC: make configurable
            response.ContentType = "application/json";
            return response.WriteAsync(json);
        }
    }
}