namespace RestClient.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Client.Interfaces;
    using Builders.Interfaces;
    using Serializers.Interfaces;
    using Contracts.Interfaces;
    using Exceptions;
    using Contracts;
    using System.Linq;

    public class RestClient : IRestClient
    {
        private readonly HttpClient _client;
        private readonly IHttpRequestBuilder _httpRequestBuilder;
        private readonly ISerializer _serializer;
        private readonly IExecutor _executor;

        public RestClient(HttpClient client, IHttpRequestBuilder httpRequestBuilder, ISerializer serializer, IExecutor executor)
        {
            _client = client;
            _httpRequestBuilder = httpRequestBuilder;
            _serializer = serializer;
            _executor = executor;
        }

        private IHttpContext GenerateHttpContext(Uri uri, HttpMethod method, IDictionary<string, string> headers, object request = null)
        {
            return new HttpContext
            {
                Request = new Request(uri, method.ToString(), request, headers)
            };
        }

        private HttpRequestMessage BuildRequestMessage(HttpMethod method, Uri uri, IDictionary<string, string> headers, object request = null)
        {
            return _httpRequestBuilder.New()
                .ToUri(uri)
                .WithContent(request)
                .WithHeaders(headers)
                .WithMethod(method)
                .Build();
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(HttpRequestMessage requestMessage, IHttpContext httpContext = null)
            where TResponse : class
        {
            await _executor.Execute(async () =>
            {
                var responseMessage = await _client.SendAsync(requestMessage);
                var content = await responseMessage.Content.ReadAsStringAsync();
                var headers = responseMessage.Headers.ToDictionary(n => n.Key, n => string.Join(" ", n.Value));

                httpContext.Response = new Response(content, (int)responseMessage.StatusCode, headers);
            }, httpContext);

            if (!httpContext.Response.IsSuccessStatusCode)
            {
                throw new RestClientException(httpContext.Response.Content, httpContext.Response.StatusCode);
            }

            return _serializer.Deserialize<TResponse>(httpContext.Response.Content);
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null)
            where TRequest : class
            where TResponse : class
        {
            var httpContext = GenerateHttpContext(uri, HttpMethod.Delete, headers, request);
            var requestMessage = BuildRequestMessage(HttpMethod.Delete, uri, headers, request);

            return await ExecuteAsync<TResponse>(requestMessage, httpContext);
        }

        public async Task<TResponse> GetAsync<TResponse>(Uri uri, IDictionary<string, string> headers = null) where TResponse : class
        {
            var httpContext = GenerateHttpContext(uri, HttpMethod.Get, headers);
            var requestMessage = BuildRequestMessage(HttpMethod.Get, uri, headers);

            return await ExecuteAsync<TResponse>(requestMessage, httpContext);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null)
            where TRequest : class
            where TResponse : class
        {
            var httpContext = GenerateHttpContext(uri, HttpMethod.Post, headers, request);
            var requestMessage = BuildRequestMessage(HttpMethod.Post, uri, headers, request);

            return await ExecuteAsync<TResponse>(requestMessage, httpContext);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null)
            where TRequest : class
            where TResponse : class
        {
            var httpContext = GenerateHttpContext(uri, HttpMethod.Put, headers, request);
            var requestMessage = BuildRequestMessage(HttpMethod.Put, uri, headers, request);

            return await ExecuteAsync<TResponse>(requestMessage, httpContext);
        }
    }
}
