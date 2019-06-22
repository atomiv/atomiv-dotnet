using Optivem.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Optivem.Infrastructure.AspNetCore
{
    public class ControllerClient : IControllerClient
    {
        public ControllerClient(IClient client, IObjectClient objectClient, string controllerUri)
        {
            Client = client;
            ObjectClient = objectClient;
            ControllerUri = controllerUri;
        }

        public IClient Client { get; private set; }

        public IObjectClient ObjectClient { get; private set; }

        public string ControllerUri { get; private set; }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TRequest, TResponse>(TRequest request)
        {
            var queryString = GetQueryString(request);
            var relativeUri = GetRelativeUri(null, queryString);
            return GetAsync<TResponse>(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>()
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetAsync()
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetAsync(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetByIdAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PostAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PostAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request)
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PostAsync<TRequest>(TRequest request)
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.PostAsync(relativeUri, request);
        }
        public Task<IObjectClientResponse<TResponse>> PostSubAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PutAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PutAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PutByIdAsync<TId, TRequest>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> DeleteAsync(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.DeleteAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> DeleteByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> DeleteByIdAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync(relativeUri);
        }

        public Task<IClientResponse> GetAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.GetAsync(relativeUri, acceptType);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PostAsync(relativeUri, content, contentType, acceptType);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PostAsync(relativeUri, content, contentType);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PutAsync(relativeUri, content, contentType, acceptType);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PutAsync(relativeUri, content, contentType);
        }

        public Task<IClientResponse> DeleteAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.DeleteAsync(relativeUri, acceptType);
        }

        #region Helper

        private string GetRelativeUriById<TId>(TId id)
        {
            return $"{ControllerUri}/{id}";
        }

        private string GetRelativeUri(string uri = null, string query = null)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(ControllerUri);

            if(uri != null)
            {
                stringBuilder.Append($"/{uri}");
            }

            if(query != null)
            {
                stringBuilder.Append($"?{query}");
            }

            var str = stringBuilder.ToString();

            return str;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private static string GetQueryString<TRequest>(TRequest request)
        {
            // TODO: VC: Make module for reflection helpers
            var type = typeof(TRequest);
            var properties = type.GetProperties();

            var propertyValues = properties
                .Select(e => Property.From(request, e))
                .ToList();

            var queryParameters = propertyValues
                .Where(e => e.Value != null)
                .Select(e => QueryParameter.From(e))
                .ToList();

            var queryString = QueryString.From(queryParameters);

            return queryString;
        }

        private class Property
        {
            public Property(string name, object value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; }

            public object Value { get; }

            public static Property From<T>(T obj, PropertyInfo propertyInfo)
            {
                var name = propertyInfo.Name;
                var value = propertyInfo.GetValue(obj, null);

                return new Property(name, value);
            }
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

            public static QueryParameter From(Property property)
            {
                var name = property.Name;
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