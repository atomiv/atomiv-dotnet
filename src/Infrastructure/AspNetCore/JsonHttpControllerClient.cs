using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Reflection;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class JsonHttpControllerClient : IControllerClient
    {
        public JsonHttpControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer, string controllerUri)
        {
            Client = new WebClient(httpClient);
            ObjectClient = new JsonClient(Client, jsonSerializer);
            PropertyFactory = new PropertyMapper();
            ControllerUri = controllerUri;
        }

        public IClient Client { get; private set; }

        public IObjectClient ObjectClient { get; private set; }

        public IPropertyMapper PropertyFactory { get; private set; }

        public string ControllerUri { get; private set; }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TRequest, TResponse>(TRequest request)
        {
            var queryString = GetQueryString(request);
            var relativeUri = GetRelativeByQuery(queryString);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var queryString = GetQueryString(request);
            var relativeUri = GetRelativeByPathQuery(uri, queryString);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>()
        {
            var relativeUri = GetRelativeByPath();
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetNoResponseAsync()
        {
            var relativeUri = GetRelativeByPath();
            return Client.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetAsync(string uri)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetByIdNoResponseAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return Client.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.PostAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> PostNoResponseAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.PostNoResponseAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request)
        {
            var relativeUri = GetRelativeByPath();
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PostNoResponseAsync<TRequest>(TRequest request)
        {
            var relativeUri = GetRelativeByPath();
            return ObjectClient.PostNoResponseAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PostSubAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PutNoResponseAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.PutNoResponseAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PutByIdNoResponseAsync<TId, TRequest>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutNoResponseAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeByPath(uri);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> DeleteAsync(string uri)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.DeleteAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> DeleteByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> DeleteByIdNoResponseAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return Client.DeleteAsync(relativeUri);
        }

        public Task<IClientResponse> GetAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.GetAsync(relativeUri, acceptType);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.PostAsync(relativeUri, content, contentType, acceptType);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.PostAsync(relativeUri, content, contentType);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.PutAsync(relativeUri, content, contentType, acceptType);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.PutAsync(relativeUri, content, contentType);
        }

        public Task<IClientResponse> DeleteAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeByPath(uri);
            return Client.DeleteAsync(relativeUri, acceptType);
        }

        #region Helper

        private string GetRelativeUriById<TId>(TId id)
        {
            return $"{ControllerUri}/{id}";
        }

        /*
        private string GetPathSuffix(string path)
        {
            return $"/{path}";
        }

        private string GetQuerySuffix(string query)
        {
            return $"?{query}";
        }

        private string GetControllerUri()
        {
            return ControllerUri;
        }

        private string GetControllerUri(string uri)
        {
            return $"{ControllerUri}{uri}";
        }
        */

        private string GetRelativeByQuery(string query)
        {
            return $"{ControllerUri}?{query}";
        }

        private string GetRelativeByPathQuery(string path, string query)
        {
            return $"{ControllerUri}/{path}?{query}";
        }

        private string GetRelativeByPath(string path)
        {
            return $"{ControllerUri}/{path}";
        }

        private string GetRelativeByPath()
        {
            return ControllerUri;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private string GetQueryString<TRequest>(TRequest request)
        {
            var propertyValues = PropertyFactory.GetObjectProperties(request);

            var queryParameters = propertyValues
                .Where(e => e.Value != null)
                .Select(e => QueryParameter.From(e))
                .ToList();

            var queryString = QueryString.From(queryParameters);

            return queryString;
        }

        private class QueryParameter
        {
            public QueryParameter(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; set; }

            public string Value { get; set; }

            public override string ToString()
            {
                return $"{Name}={Value}";
            }

            public static QueryParameter From(IObjectProperty property)
            {
                var name = property.TypeProperty.Name;
                var value = property.Value;
                var stringValue = value.ToString();
                var encodedValue = HttpUtility.UrlEncode(stringValue);

                return new QueryParameter(name, encodedValue);
            }
        }

        private class QueryString
        {
            public static string From(IEnumerable<QueryParameter> queryParameters)
            {
                var queryParameterStrings = queryParameters.Select(e => e.ToString()).ToList();
                var queryString = string.Join("&", queryParameterStrings);
                return queryString;
            }
        }

        #endregion Helper
    }
}
