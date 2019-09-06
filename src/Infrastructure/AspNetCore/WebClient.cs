using Optivem.Framework.Core.Common.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class WebClient : IClient
    {
        private static Encoding StringContentEncoding = Encoding.UTF8;

        public WebClient(HttpClient client)
        {
            HttpClient = client;
        }

        protected HttpClient HttpClient { get; private set; }


        public Task<IClientResponse> GetAsync(string uri, string accept)
        {
            var message = CreateMessage(HttpMethod.Get, uri, null, null, accept);
            return SendReadResponseAsync(message);
        }

        public Task<IClientResponse> GetAsync(string uri)
        {
            var message = CreateMessage(HttpMethod.Get, uri, null, null, null);
            return SendNoResponseAsync(message);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            var message = CreateMessage(HttpMethod.Post, uri, content, contentType, acceptType);
            return SendReadResponseAsync(message);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            var message = CreateMessage(HttpMethod.Put, uri, content, contentType, acceptType);
            return SendReadResponseAsync(message);
        }

        public Task<IClientResponse> DeleteAsync(string uri, string acceptType)
        {
            var message = CreateMessage(HttpMethod.Delete, uri, null, null, acceptType);
            return SendReadResponseAsync(message);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType)
        {
            var message = CreateMessage(HttpMethod.Post, uri, content, contentType, null);
            return SendNoResponseAsync(message);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType)
        {
            var message = CreateMessage(HttpMethod.Put, uri, content, contentType, null);
            return SendNoResponseAsync(message);
        }

        public Task<IClientResponse> DeleteAsync(string uri)
        {
            var message = CreateMessage(HttpMethod.Delete, uri, null, null, null);
            return SendNoResponseAsync(message);
        }

        public void Dispose()
        {
            // No action
        }

        #region Helper


        private HttpRequestMessage CreateMessage(HttpMethod method, string uri, string content, string contentType, string acceptType)
        {
            var requestUri = new Uri(HttpClient.BaseAddress, uri);

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

            if (content != null)
            {
                var requestContent = new StringContent(content, StringContentEncoding, contentType);
                requestMessage.Content = requestContent;
            }

            // TODO: VC:
            var hasHeaders = contentType != null || acceptType != null;

            return requestMessage;
        }

        private async Task<IClientResponse> SendAsync(HttpRequestMessage message, bool expectContent)
        {
            using (var response = await HttpClient.SendAsync(message))
            {
                var isSuccessStatusCode = response.IsSuccessStatusCode;
                var statusCode = response.StatusCode;
                var contentLength = response.Content.Headers.ContentLength;
                // TODO: VC: Check if content exists and length?

                var content = await response.Content.ReadAsStringAsync();

                return new ClientResponse(isSuccessStatusCode, statusCode, content);

                // TODO: VC: Check if should throw?

                /*

                if (!isSuccessStatusCode)
                {
                    throw new ClientException(statusCode, content);
                }

                */

                // TODO: VC: Exception for null content

                /*
                if (expectContent && content == null)
                {
                    throw new Exception();
                }
                */
            }
        }

        protected async Task<IClientResponse> SendReadResponseAsync(HttpRequestMessage message)
        {
            var response = await SendAsync(message, true);
            return response;
        }

        protected Task<IClientResponse> SendNoResponseAsync(HttpRequestMessage message)
        {
            return SendAsync(message, false);
        }

        #endregion Helper
    }
}