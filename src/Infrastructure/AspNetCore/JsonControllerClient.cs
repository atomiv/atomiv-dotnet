using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Reflection;
using Optivem.Atomiv.Core.Common.Serialization;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class JsonControllerClient : ControllerClient
    {
        public JsonControllerClient(IClient client, IJsonSerializer serializer, IPropertyMapper propertyFactory, string controllerPath)
            : base(client, new JsonClient(client, serializer), propertyFactory, controllerPath)
        {
        }
    }
}