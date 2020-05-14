using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Web.RestClient.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Atomiv.Template.Web.RestClient
{
    public class BaseJsonControllerClient
    {
        public BaseJsonControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer, string controllerUri)
        {
            Client = new JsonHttpControllerClient(httpClient, jsonSerializer, controllerUri);
        }

        protected JsonHttpControllerClient Client { get; }

        // TODO: VC: Continue

            /*
        protected RequestHeaderCollection GetHeaders(HeaderData headerData)
        {
            var headers = new List<RequestHeader>();
        }
        */
    }
}
