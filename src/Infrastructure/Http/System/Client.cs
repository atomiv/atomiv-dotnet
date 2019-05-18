using Optivem.Common.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Http.System
{
    public class Client : IClient
    {
        private static Encoding StringContentEncoding = Encoding.UTF8;

        public Client(HttpClient client)
        {
            HttpClient = client;
        }

        protected HttpClient HttpClient { get; private set; }

        private HttpRequestMessage CreateMessage(HttpMethod method, string uri, string content, string contentType, string acceptType)
        {
            var requestUri = GetUri(uri);

            var requestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = requestUri,
                Headers =
                {
                    { HttpRequestHeader.ContentType.ToString(), contentType },
                    { HttpRequestHeader.Accept.ToString(), acceptType }
                },
            };

            if(content != null)
            {
                var requestContent = new StringContent(content, StringContentEncoding, contentType);
                requestMessage.Content = requestContent;
            }

            // TODO: VC:
            var hasHeaders = contentType != null || acceptType != null;

            return requestMessage;
        }

        public Task<string> GetAsync(string uri, string accept)
        {
            var message = CreateMessage(HttpMethod.Get, uri, null, null, accept);
            return SendReadResponseAsync(message);
        }

        public Task GetAsync(string uri)
        {
            var message = CreateMessage(HttpMethod.Get, uri, null, null, null);
            return SendNoResponseAsync(message);
        }

        public Task<string> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            var message = CreateMessage(HttpMethod.Post, uri, content, contentType, acceptType);
            return SendReadResponseAsync(message);
        }

        public Task<string> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            var message = CreateMessage(HttpMethod.Put, uri, content, contentType, acceptType);
            return SendReadResponseAsync(message);
        }

        public Task<string> DeleteAsync(string uri, string acceptType)
        {
            var message = CreateMessage(HttpMethod.Delete, uri, null, null, acceptType);
            return SendReadResponseAsync(message);
        }

        public Task PostAsync(string uri, string content, string contentType)
        {
            var message = CreateMessage(HttpMethod.Post, uri, content, contentType, null);
            return SendNoResponseAsync(message);
        }

        public Task PutAsync(string uri, string content, string contentType)
        {
            var message = CreateMessage(HttpMethod.Put, uri, content, contentType, null);
            return SendNoResponseAsync(message);
        }

        public Task DeleteAsync(string uri)
        {
            var message = CreateMessage(HttpMethod.Delete, uri, null, null, null);
            return SendNoResponseAsync(message);
        }

        public void Dispose()
        {
            // No action
            // TODO: VC: Check where client was created?
        }

        #region Helper

        private Uri GetUri(string uri)
        {
            return new Uri(HttpClient.BaseAddress, uri);
        }

        private async Task<string> SendAsync(HttpRequestMessage message, bool expectContent)
        {
            using (var response = await HttpClient.SendAsync(message))
            {
                var isSuccessStatusCode = response.IsSuccessStatusCode;
                var statusCode = response.StatusCode;
                var content = await response.Content.ReadAsStringAsync();

                if(!isSuccessStatusCode)
                {
                    throw new ClientException(statusCode, content);
                }

                // TODO: VC: Exception for null content
                
                /*
                if (expectContent && content == null)
                {
                    throw new Exception();
                }
                */

                return content;
            }
        }

        protected async Task<string> SendReadResponseAsync(HttpRequestMessage message)
        {
            var response = await SendAsync(message, true);
            return response;
        }

        protected Task SendNoResponseAsync(HttpRequestMessage message)
        {
            return SendAsync(message, false);
        }

        #endregion
    }
}
