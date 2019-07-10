using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Reflection;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class JsonControllerClient : ControllerClient
    {
        public JsonControllerClient(IClient client, IJsonSerializer serializer, IPropertyMapper propertyFactory, string controllerPath)
            : base(client, new JsonClient(client, serializer), propertyFactory, controllerPath)
        {
        }
    }
}