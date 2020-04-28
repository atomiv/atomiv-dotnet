using Optivem.Atomiv.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class WebClient : IClient
    {
        private static Encoding StringContentEncoding = Encoding.UTF8;

        public WebClient(HttpClient client)
        {
            HttpClient = client;
        }

        protected HttpClient HttpClient { get; private set; }

        public Task<ClientResponse> GetAsync(string uri, IEnumerable<RequestHeader> headers)
        {
            var message = CreateMessage(HttpMethod.Get, uri, null, headers);
            return SendReadResponseAsync(message);
        }

        public Task<ClientResponse> PostAsync(string uri, string content, IEnumerable<RequestHeader> headers)
        {
            var message = CreateMessage(HttpMethod.Post, uri, content, headers);
            return SendReadResponseAsync(message);
        }

        public Task<ClientResponse> PutAsync(string uri, string content, IEnumerable<RequestHeader> headers)
        {
            var message = CreateMessage(HttpMethod.Put, uri, content, headers);
            return SendReadResponseAsync(message);
        }

        public Task<ClientResponse> DeleteAsync(string uri, IEnumerable<RequestHeader> headers)
        {
            var message = CreateMessage(HttpMethod.Delete, uri, null, headers);
            return SendReadResponseAsync(message);
        }

        #region Helper

        private HttpRequestMessage CreateMessage(HttpMethod method, string uri, string content, IEnumerable<RequestHeader> requestHeaders)
        {
            var requestUri = new Uri(HttpClient.BaseAddress, uri);

            var headers = requestHeaders.Select(e => new { e.Name, e.Value }).ToList();

            var requestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = requestUri,
            };

            foreach(var header in headers)
            {
                requestMessage.Headers.Add(header.Name, header.Value);
            }

            if (content != null)
            {
                var requestHeader = requestHeaders.FirstOrDefault(e => e.Name == HttpRequestHeader.ContentType.ToString());
                var mediaType = requestHeader?.Value;
                var requestContent = new StringContent(content, StringContentEncoding, mediaType);
                requestMessage.Content = requestContent;
            }

            return requestMessage;
        }

        private async Task<ClientResponse> SendAsync(HttpRequestMessage message, bool expectContent)
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

        protected async Task<ClientResponse> SendReadResponseAsync(HttpRequestMessage message)
        {
            var response = await SendAsync(message, true);
            return response;
        }

        protected Task<ClientResponse> SendNoResponseAsync(HttpRequestMessage message)
        {
            return SendAsync(message, false);
        }

        #endregion Helper
    }
}