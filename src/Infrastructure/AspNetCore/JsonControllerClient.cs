using Atomiv.Core.Common.Http;
using Atomiv.Core.Common.Reflection;
using Atomiv.Core.Common.Serialization;

namespace Atomiv.Infrastructure.AspNetCore
{
    public class JsonControllerClient : ControllerClient
    {
        public JsonControllerClient(IClient client, IJsonSerializer serializer, IPropertyMapper propertyFactory, string controllerPath)
            : base(client, new JsonClient(client, serializer), propertyFactory, controllerPath)
        {
        }
    }
}